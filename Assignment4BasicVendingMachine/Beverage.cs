using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4BasicVendingMachine
{
    public class Beverage : ProductItem
    {
        public new string UseText;

        public Beverage(string productName, int price, string description) : base(productName, price, description)
        {

        }
        public override string Use()
        {
            UseText = ($"You drink the {ProductName}. That was refreshing!");
            return UseText;
        }
    }
}
