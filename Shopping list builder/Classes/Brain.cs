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
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(json);
            }
        }


        public static string SaveRecipesJSON()
        {
            string json = SerializeRecipeListToJson(Brain.RecipesDatabase);
            SaveJsonToFile(json, "userSavedRecipe.json");
            return json;
        }

        public static string LoadRecipesJSON()
        {
            if (File.Exists("userSavedRecipe.json"))
            {
                string jsonString = File.ReadAllText("userSavedRecipe.json");
                Brain.RecipesDatabase = Read(jsonString);
                return jsonString;
            }
            return "No Json to load from";
        }


        public static List<Recipe> Read(string jsonString)
        {
            List<Recipe> recipes = new List<Recipe>();

            // Deserialize the JSON string into a JsonDocument
            using (JsonDocument document = JsonDocument.Parse(jsonString))
            {
                // Get the root array of the JSON document
                JsonElement root = document.RootElement;

                // Iterate over each element in the array
                foreach (JsonElement recipeElement in root.EnumerateArray())
                {
                    // Extract Recipe properties
                    string name = recipeElement.GetProperty("Name").GetString();
                    string description = recipeElement.GetProperty("Description").GetString();

                    // Extract the 'Items' array
                    List<Item> items = new List<Item>();
                    if (recipeElement.TryGetProperty("Items", out JsonElement itemsElement))
                    {
                        foreach (JsonElement itemElement in itemsElement.EnumerateArray())
                        {
                            string id = itemElement.GetProperty("ID").GetString();
                            double amount = itemElement.GetProperty("Amount").GetDouble();
                            string unit = itemElement.GetProperty("Unit").GetString();

                            // Create Item object and add it to the list
                            Item item = new Item(id,amount,unit);
                            items.Add(item);
                        }
                    }

                    // Create Recipe object and add it to the list
                    Recipe recipe = new Recipe(name,description);
                    recipe.items = items;
                    recipes.Add(recipe);
                }
            }

            return recipes;
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
