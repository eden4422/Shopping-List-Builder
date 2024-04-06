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



        public string JsonFilePath { get; set; }

        public Brain(string jsonFilePath)
        {
            JsonFilePath = jsonFilePath;
        }



        public static List<Dictionary<string, int>> ParseJsonToListOfDictionaries(string jsonString)
        {
            return JsonSerializer.Deserialize<List<Dictionary<string, int>>>(jsonString);
        }

        public static List<Recipe> ListOfDictionariesToListOfRecipes(List<Dictionary<string, int>> dictionaryList)
        {
            List<Recipe> recipeList = new List<Recipe>();

            foreach()


            return recipeList;
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
