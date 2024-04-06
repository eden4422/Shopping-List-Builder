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


namespace Shopping_list_builder.Classes
{

    public class ShoppingAlgorithm
    {

        public static string DoStuff()
        {
            List<Dictionary<string, double>> stores = new List<Dictionary<string, double>> { new Dictionary<string, double> { { "apple", 2.50 }, { "banana", 1.20 }, { "orange", 1.80 } }, new Dictionary<string, double> { { "apple", 2.20 }, { "banana", 1.10 }, { "orange", 2.00 } }, new Dictionary<string, double> { { "apple", 2.00 }, { "banana", 1.30 }, { "orange", 1.90 } } };

            // List of store names
            List<string> storeNames = new List<string> { "Store A", "Store B", "Store C" };

            // List of products you want
            List<string> desiredProducts = new List<string> { "apple", "banana", "orange", "pear" }; // "pear" is not available in any store

            (List<string> bestStoreNames, Dictionary<string, List<string>> productsToBuy, double totalPrice) = FindBestCombinationStores(stores, storeNames, desiredProducts, 2);

            Console.WriteLine("Best combination of stores:");

            string output = "";
            
            foreach (string storeName in bestStoreNames)
            {
                output += "\n" + storeName;
                output += "\n" + "Products to buy: " + string.Join(", ", productsToBuy[storeName]);
            }

            return output;

        }

        static (List<string>, Dictionary<string, List<string>>, double) FindBestCombinationStores(List<Dictionary<string, double>> stores, List<string> storeNames, List<string> desiredProducts, int storeLimit)
        {
            List<string> bestStoreNames = new List<string>();
            Dictionary<string, List<string>> productsToBuy = new Dictionary<string, List<string>>();

            // Generate combinations of stores
            List<List<int>> combinations = GenerateCombinations(stores.Count, storeLimit);

            double minPrice = double.MaxValue;
            double totalPrice = 0;

            // Iterate through each combination
            foreach (var combination in combinations)
            {
                double currentTotalPrice = 0;
                Dictionary<string, List<string>> tempProductsToBuy = new Dictionary<string, List<string>>();

                // Calculate the total price and products for the combination
                foreach (string product in desiredProducts)
                {
                    double productPrice = double.MaxValue;
                    string storeName = null;

                    // Find the minimum price for the current product among the stores in the combination
                    foreach (int index in combination)
                    {
                        if (stores[index].ContainsKey(product) && stores[index][product] < productPrice)
                        {
                            productPrice = stores[index][product];
                            storeName = storeNames[index];
                        }
                    }

                    // If the product is not found in any store, continue to the next product
                    if (storeName == null)
                        continue;

                    // Add the product to the list of products to buy from the corresponding store
                    if (!tempProductsToBuy.ContainsKey(storeName))
                    {
                        tempProductsToBuy[storeName] = new List<string>();
                    }
                    tempProductsToBuy[storeName].Add(product);

                    currentTotalPrice += productPrice;
                }

                // Update the minimum total price and best store names if a new minimum is found
                if (currentTotalPrice < minPrice)
                {
                    minPrice = currentTotalPrice;
                    bestStoreNames = combination.Select(index => storeNames[index]).ToList();
                    productsToBuy = new Dictionary<string, List<string>>(tempProductsToBuy);
                    totalPrice = currentTotalPrice;
                }
            }

            return (bestStoreNames, productsToBuy, totalPrice);
        }

        // Helper method to generate combinations of store indices with the specified limit
        static List<List<int>> GenerateCombinations(int n, int k)
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






    }


}
