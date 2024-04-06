using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Documents;
using System.Xml;


namespace Shopping_list_builder.Classes
{

    public class Brain
    {
        // All Recipes created by user and shopping lists (data passed between views)
        public static String LocalRecipesJson { get; set; }
        public static String LocalShoppingListJson { get; set; }

        // JSON data for views that won't be passed around
        public static String RecipeBuilderState { get; set; }
        public static String ShoppingListRecipeState { get; set; }

        public static List<Recipe> RecipesDatabase = new List<Recipe>();

        public static List<Item> ShoppingListDatabase = new List<Item>();
        

        public string JsonFilePath { get; set; }

        public Brain(string jsonFilePath)
        {
            JsonFilePath = jsonFilePath;
        }

        public static string SerializeRecipeListToJson(List<Recipe> recipes)
        {
            return JsonSerializer.Serialize(recipes);
        }

        public static string SerializeItemListToJson(List<Item> items)
        {
            return JsonSerializer.Serialize(items);
        }

        public static List<Recipe> DeserializeJsonToRecipeList(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Recipe>>(jsonString);
        }

        public static List<Item> DeserializeJsonToItemList(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Item>>(jsonString);
        }



        public static void SaveJsonToFile(string json, string filePath)
        {
            File.WriteAllText(filePath, json);
        }






        public static void SaveJson(string jsonString, string path)
        {
            try
            {
                File.WriteAllText(path, jsonString);
                Console.WriteLine("JSON data saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving JSON data: {ex.Message}");
            }
        }

        private T LoadJson<T>()
        {
            try
            {
                if (File.Exists(JsonFilePath))
                {
                    string jsonData = File.ReadAllText(JsonFilePath);
                    T deserializedData = JsonSerializer.Deserialize<T>(jsonData);
                    Console.WriteLine("JSON data loaded successfully.");
                    return deserializedData;
                }
                else
                {
                    Console.WriteLine("JSON file not found.");
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON data: {ex.Message}");
                return default(T);
            }
        }
    }

}
