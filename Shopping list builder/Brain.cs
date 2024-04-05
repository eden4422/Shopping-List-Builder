using System;
using System.IO;
using System.Text.Json;

public class Brain
{
    public string JsonFilePath { get; set; }

    public Brain(string jsonFilePath)
    {
        JsonFilePath = jsonFilePath;
    }

    public void SaveJson(object data)
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

    public T LoadJson<T>()
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
