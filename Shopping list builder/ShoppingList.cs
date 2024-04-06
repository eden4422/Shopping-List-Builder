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
        public ObservableCollection<Grocery> groceries { get; set; }
        
        public ShoppingList()
        {
            // Initialize and set the data context of the ListView
            groceries = new ObservableCollection<Grocery>();
            groceries.Add(new Grocery(5, "Apples"));
            groceries.Add(new Grocery(3, "Bananas"));
            groceries.Add(new Grocery(2, "Cheddar Cheese"));
        }

        public void addGrocery(string selectedItem)
        {
            bool flag = true;
            foreach (Grocery grocery in groceries)
            {
                if (grocery.GroceryName == selectedItem)
                {
                    grocery.Quantity += 1;
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                groceries.Add(new Grocery(1, selectedItem));
            }
        }

        public class Grocery
        {
            public Grocery(int Quantity, string GroceryName)
            {
                this.Quantity = Quantity;
                this.GroceryName = GroceryName;
            }

            public int Quantity { get; set; }
            public string GroceryName { get; set; }
        }
    }
}
