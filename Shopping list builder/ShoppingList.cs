﻿using Shopping_list_builder.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_list_builder
{
    public class ShoppingList
    {
        public ObservableCollection<Item> groceries { get; set; }


        public ShoppingList()
        {
            // Initialize and set the data context of the ListView
            groceries = new ObservableCollection<Item>();
            // groceries.Add(new Item("Apples", 3));
            // groceries.Add(new Item("Bananas", 3));
            // groceries.Add(new Item("Cheddar Cheese", 3));
        }

        public void addItem(Item selectedItem)
        {
            bool flag = true;
            foreach (Item grocery in groceries)
            {
                if (grocery.ID == selectedItem.ID)
                {
                    grocery.addPortion(selectedItem.amount);
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                groceries.Add(new Item(selectedItem.ID, selectedItem.amount, selectedItem.Unit));
            }
        }

        public List<Item> ToList()
        {
            return this.groceries.ToList();
        }
    }
}
