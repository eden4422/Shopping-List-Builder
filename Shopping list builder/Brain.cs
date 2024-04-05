using System;
using System.IO;
using System.Text.Json;
using System.Windows.Documents;

public class Brain
{
    // All Recipes created by user and shopping lists (data passed between views)
    public String LocalRecipesJson { get; set; }
    public String LocalShoppingListJson { get; set; }
    
    // JSON data for views that won't be passed around
    public String RecipeBuilderState { get; set; }
    public String ShoppingListRecipeState { get; set; }





    

    public string JsonFilePath { get; set; }

    public Brain(string jsonFilePath)
    {
        JsonFilePath = jsonFilePath;
    }

    private void SaveJson(object data)
    {
        try
        {
            string jsonData = JsonSerializer.Serialize(data);
            File.WriteAllText(JsonFilePath, jsonData);
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
