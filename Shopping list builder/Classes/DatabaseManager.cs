﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shopping_list_builder.Classes
{
    internal class DatabaseManager
    {
        public void signUpUser(string username, string password)
        {
            // Create a new MongoClient instance
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");

            // Get a reference to the database
            var database = dbClient.GetDatabase("Hackathon");

            // Get a reference to the collection
            var collection = database.GetCollection<BsonDocument>("UserLogIns");

            string id = "6611169c3d0c11da34d6ffa3";

            

            // Create a filter to match the document with the specified _id
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));

            // Create an update definition to add the new username and password combo to the user field
            var update = Builders<BsonDocument>.Update.Set("user." + username, password);

            // Execute the update operation
            collection.UpdateOne(filter, update);
        }

        // Look up user.
        public bool logInUser(string username, string password)
        {
            // Create a new MongoClient instance
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");

            // Get a reference to the database
            var database = dbClient.GetDatabase("Hackathon");

            // Get a reference to the collection
            var collection = database.GetCollection<BsonDocument>("UserLogIns");

            string id = "6611169c3d0c11da34d6ffa3";

            // Create a filter to match the document with the specified _id
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));

            // Retrieve the document
            var document = collection.Find(filter).FirstOrDefault();

            // Check if the username exists and the password matches
            if (document["user"].AsBsonDocument.Contains(username) && document["user"][username] == password)
            {
                return true;
            }

            return false;
        }
    }
}