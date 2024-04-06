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
        public string unit = "unit";

        public Item(string name, double startingAmount, string u)
        { 
            this.itemID = name;
            this.amount = startingAmount;
            this.unit = u;
        }

        public string ID { get { return itemID;} }
        public double Amount { get { return amount;} }
        public string Unit { get { return unit;} }

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
