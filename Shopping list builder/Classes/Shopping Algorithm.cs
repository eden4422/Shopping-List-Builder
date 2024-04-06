using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Documents;
using System.Xml;
using System.Xml.Serialization;


namespace Shopping_list_builder.Classes
{

    public class ShoppingAlgorithm
    {
        public ShoppingAlgorithm()
        {
            List<ShoppingTriple> triples = new List<ShoppingTriple>();
        }

        public static string FindValues(List<Item> items)
        {
            toFind = ConvertToStringList(items);








            return "";
        }



        public static List<string> ConvertToStringList(List<Item> items)
        {
            List<string> stringlist = new List<string>();

            return stringlist;
        }
    }


    public class ShoppingTriple
    {
        public string name = "";
        public string store = "";
        public double price = 0.0;

    }


}
