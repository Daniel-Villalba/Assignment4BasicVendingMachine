using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4BasicVendingMachine
{
    public abstract class ProductItem
    {
        public string UseText = "";
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Description;

        public ProductItem(string productName, int price, string description)
        {
            ProductName = productName;
            Price = price;
            Description = description;
        }
        public void Examine()
        {
            Console.WriteLine($"Product: {ProductName}\tPrice: {Price}\tDescription: {Description}");
        }
        public virtual string Use()
        {
            return UseText;
        }
    }
}
