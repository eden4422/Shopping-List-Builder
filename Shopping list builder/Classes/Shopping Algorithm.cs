using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Documents;
using System.Xml;
using System.Xml.Serialization;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;


namespace Shopping_list_builder.Classes
{

    public class ShoppingAlgorithm
    {

        public static List<Dictionary<string, double>> storesFromFile;
        public static List<string> storeNames;

        public static void WriteJSONBusinesses()
        {
                List<Dictionary<string, double>> stores = new List<Dictionary<string, double>>
            {
                new Dictionary<string, double> { { "apple", 2.50 }, { "banana", 1.20 }, { "orange", 1.80 } },
                new Dictionary<string, double> { { "apple", 2.20 }, { "banana", 1.10 }, { "orange", 2.00 } },
                new Dictionary<string, double> { { "apple", 2.00 }, { "banana", 1.30 }, { "orange", 1.90 } }
            };

            List<string> sNames = new List<string> { "Walmart 433 Bickford Avenu", "Target 3245 Likeland Square", "QFC Broadway 91st" };


            // Write the list of dictionaries to JSON file
            WriteToJsonFile("storesStats.json", stores);
            WriteToJsonFile("storesNames.json", sNames);
        }

        public static void ReadJSONBusinesses()
        {
            storesFromFile = ReadFromJsonFile<List<Dictionary<string, double>>>("storesStats.json");
            storeNames = ReadFromJsonFile<List<string>>("storesNames.json");
        }

        static T ReadFromJsonFile<T>(string fileName)
        {
            T data;
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                data = JsonSerializer.Deserialize<T>(jsonString);
                Console.WriteLine($"Data has been read from {fileName}.");
            }
            else
            {
                Console.WriteLine($"File {fileName} not found. Creating a new file.");
                data = default(T);
                WriteToJsonFile(fileName, data);
            }
            return data;
        }

        // Function to write a list of dictionaries to a JSON file
        static void WriteToJsonFile<T>(string fileName, T data)
        {
            string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, jsonString);
            Console.WriteLine($"Data has been written to {fileName}.");
        }



        public static string CreateShoppingList(List<Item> items, int maxStores, double maxDistance)
        {
            WriteJSONBusinesses();
            ReadJSONBusinesses();




            List<Dictionary<string, double>> stores = storesFromFile;

            // List of store names

            // List of products you want with their quantities
            Dictionary<string, int> desiredProducts = ConvertItemToDictionary(items);

            (List<string> bestStoreNames, Dictionary<string, Dictionary<string, int>> productsToBuy, double totalPrice) = FindBestCombinationStores(stores, storeNames, desiredProducts);

            Console.WriteLine("Best combination of stores:");

            string output = "";

            double grandTotal = 0;

            foreach (string storeName in bestStoreNames)
            {
                output += "\n" + storeName;
                output += "\n" + "Products to buy: ";
                double storeTotal = 0;
                foreach (var product in productsToBuy[storeName])
                {
                    double productPrice = stores[storeNames.IndexOf(storeName)][product.Key];
                    double productTotalPrice = product.Value * productPrice;
                    storeTotal += productTotalPrice;
                    output += $"{product.Key}: {product.Value} (Price per item: {productPrice:C2}), ";
                }
                output = output.TrimEnd(' ', ','); // Trim trailing comma and space
                output += $"\nStore Total: {storeTotal:C2}";
                grandTotal += storeTotal;
            }

            output += $"\nGrand Total for the trip: {grandTotal:C2}";

            return output;
        }

        static (List<string>, Dictionary<string, Dictionary<string, int>>, double) FindBestCombinationStores(List<Dictionary<string, double>> stores, List<string> storeNames, Dictionary<string, int> desiredProducts)
        {
            List<string> bestStoreNames = new List<string>();
            Dictionary<string, Dictionary<string, int>> productsToBuy = new Dictionary<string, Dictionary<string, int>>();

            // Generate combinations of stores
            List<List<int>> combinations = GenerateCombinations(stores.Count);

            double minPrice = double.MaxValue;
            double totalPrice = 0;

            // Iterate through each combination
            foreach (var combination in combinations)
            {
                double currentTotalPrice = 0;
                Dictionary<string, Dictionary<string, int>> tempProductsToBuy = new Dictionary<string, Dictionary<string, int>>();

                // Calculate the total price and products for the combination
                foreach (string product in desiredProducts.Keys)
                {
                    double productPrice = double.MaxValue;
                    string storeName = null;

                    // Find the minimum price for the current product among the stores in the combination
                    foreach (int index in combination)
                    {
                        // Check if the product is available in the current store
                        if (stores[index].ContainsKey(product) && stores[index][product] < productPrice)
                        {
                            productPrice = stores[index][product];
                            storeName = storeNames[index];
                        }
                    }

                    // If the product is not found in any store, skip it
                    if (storeName == null)
                        continue;

                    // Calculate the quantity to buy
                    int quantityToBuy = desiredProducts[product];

                    // Add the product to the list of products to buy from the corresponding store
                    if (!tempProductsToBuy.ContainsKey(storeName))
                    {
                        tempProductsToBuy[storeName] = new Dictionary<string, int>();
                    }
                    tempProductsToBuy[storeName][product] = quantityToBuy;

                    // Calculate the total price for this product
                    currentTotalPrice += quantityToBuy * productPrice;
                }

                // Update the minimum total price and best store names if a new minimum is found
                if (currentTotalPrice < minPrice)
                {
                    minPrice = currentTotalPrice;
                    bestStoreNames = combination.Select(index => storeNames[index]).ToList();
                    productsToBuy = new Dictionary<string, Dictionary<string, int>>(tempProductsToBuy);
                    totalPrice = currentTotalPrice;
                }
            }

            return (bestStoreNames, productsToBuy, totalPrice);
        }

        // Helper method to generate combinations of store indices
        static List<List<int>> GenerateCombinations(int n)
        {
            var combinations = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    combinations.Add(new List<int> { i, j });
                }
            }

            return combinations;
        }



        public static Dictionary<string, int> ConvertItemToDictionary(List<Item> items)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach(Item item in items)
            {
                if (dict.ContainsKey(item.ID))
                {
                    dict[item.ID] += (int)item.Amount; // Increment quantity if item already exists in dictionary
                }
                else
                {
                    dict[item.ID] = (int)item.Amount; // Otherwise, add the item with quantity 1
                }
            }

            return dict;
        }

    }


}
