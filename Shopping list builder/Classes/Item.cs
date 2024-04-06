using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_list_builder.Classes
{
    public class Item
    {
        public string itemID;
        public double amount = 0;

        public Item(string name, double startingAmount)
        { 
            this.itemID = name;
            this.amount = startingAmount;
        }

        public string ID { get { return itemID;} }
        public double Amount { get { return amount;} }

        public void addPortion(double portion) 
        {
            this.amount += portion;
        }

        public void removePortion(double portion)
        {
            if (this.amount - portion >= 0)
            {
                this.amount -= portion;
            }
        }
    }
}
