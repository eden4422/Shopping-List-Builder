using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
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

            // Add User Credentials
            var userCredentials = new BsonDocument
            {
                { username, password },
            };

            collection.InsertOne(userCredentials);
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

            // Create a query to check if the user exists
            var filter = Builders<BsonDocument>.Filter.Eq(username,password);

            // Execute the query
            bool userExists = collection.Find(filter).Any();

            return userExists;
        }

    }
}
