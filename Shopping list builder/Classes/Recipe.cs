using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_list_builder.Classes
{
    public class Recipe
    {
        private string name;
        private string description;
        private List<Item> items = new List<Item>();

        public Recipe(string name, string description) 
        {
            this.name = name;
            this.description = description;
        }

        public string Name { get { return name; } }
        public string Description { get { return description; } }
        public List<Item> Items { get { return items; } }

        public void addItem(string itemName, double itemPortion, string itemUnit)
        {
            Item newItem = new Item(itemName, itemPortion, itemUnit);
            items.Add(newItem);
        }

        
        public void removeItem(string itemName)
        {
            Item? itemToRemove = items.Find(item => item.ID == itemName);
            if (itemToRemove != null)
            {
                items.Remove(itemToRemove);
            }
        }
        

        public void removePortion(string itemName,double portion)
        {
            Item? itemToRemovePortion = items.Find(item => item.ID == itemName);
            if (itemToRemovePortion != null)
            {
                itemToRemovePortion.removePortion(portion);
            }
        }

        public void addPortion(string itemName,double portion)
        {
            Item? itemToAddPortion = items.Find(item => item.ID == itemName);
            if (itemToAddPortion != null)
            {
                itemToAddPortion.addPortion(portion);
            }
        }

    }
}
