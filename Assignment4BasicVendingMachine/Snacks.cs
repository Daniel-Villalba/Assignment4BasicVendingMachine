using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4BasicVendingMachine
{
    public class Snacks : ProductItem
    {
        public new string UseText;

        public Snacks(string productName, int price, string description) : base(productName, price, description)
        {

        }
        public override string Use()
        {
            UseText = ($"You eat the {ProductName}. That was nice!");
            return UseText;
        }
    }
}
