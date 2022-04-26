using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4BasicVendingMachine
{
    public class Food : ProductItem
    {
        public new string UseText;

        public Food(string productName, int price, string description) : base(productName, price, description)
        {

        }
        public override string Use()
        {
            UseText = ($"You eat the {ProductName}. So tasty!");
            return UseText;
        }
    }
}
