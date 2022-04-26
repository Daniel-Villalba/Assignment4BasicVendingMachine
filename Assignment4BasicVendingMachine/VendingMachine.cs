using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4BasicVendingMachine
{
    public class VendingMachine : IVendingMachine
    {
        public static bool insert { get; private set; }
        private readonly int[] fixedDenominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };
        public int CustomerWallet = 0;

        public static List<ProductItem> allProducts = new List<ProductItem>()
        {
            new Beverage("coke", 15, "carbonated drink"),

            new Food("pizza slice", 35, "pizza with tomatosauce, ham and cheese"),

            new Snacks("chips", 25, "Crispy potatoesnack with sourcreme taste")

        };
        public void InsertMoney(int denominationType, int amount)
        {
            foreach (var denomination in fixedDenominations)
            {
                if (denominationType == denomination)
                {
                    CustomerWallet += denominationType * amount;
                }
            }
        }

        public ProductItem Purchase(string productname)
        {
            foreach (ProductItem productItem in allProducts)
            {
                // Check if a productname is available as product and if there is sufficient funds to purchase said item.
                if (productname.ToLower() == productItem.ProductName.ToLower() && CustomerWallet >= productItem.Price)
                {
                    CustomerWallet -= productItem.Price;
                    return productItem;
                }
            }

            Console.WriteLine("\nYou have insufficient funds!!!");
            return null;
        }
        public void ShowAll()
        {
            foreach (var productItem in allProducts)
            {
                productItem.Examine();
            }
        }

        public int[] EndTransaction()
        {
            int[] returnDenomAmount = new int[fixedDenominations.Length];
            //Check against the last index in the array (largest denomination) first
            for (int i = fixedDenominations.Length - 1; i >= 0; i--)
            {
                // Check if there is enough money in CustomerWallet for the specific denomination in question
                if ((CustomerWallet / fixedDenominations[i]) >= 0)
                {
                    // Get amount of a specific denomination in the CustomerWallet and round down to a whole number

                    var denomAmount = Math.Floor((double)(CustomerWallet / fixedDenominations[i]));
                    // Store the specific denomination amount 
                    returnDenomAmount[i] = (int)denomAmount;
                    // Uppdate the CustomerWallet by removing the amount of a specific denomination
                    CustomerWallet -= (int)(denomAmount * fixedDenominations[i]);
                }
            }

            Console.WriteLine($"1sek: {returnDenomAmount[0]}, " +
                              $" 5sek: {returnDenomAmount[1]}, " +
                              $" 10sek: {returnDenomAmount[2]}, " +
                              $" 20sek: {returnDenomAmount[3]}, " +
                              $" 50sek: {returnDenomAmount[4]}, " +
                              $" 100sek: {returnDenomAmount[5]}, " +
                              $" 500sek: {returnDenomAmount[6]}, " +
                              $" 1000sek: {returnDenomAmount[7]}, ");
            return returnDenomAmount;
        }
    }
}
