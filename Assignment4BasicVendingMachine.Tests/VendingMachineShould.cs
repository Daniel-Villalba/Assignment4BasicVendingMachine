using System;
using Xunit;

namespace Assignment4BasicVendingMachine.Tests
{
    public class VendingMachineShould
    {
        [Fact]
        public void AcceptValidDenomination()
        {
            VendingMachine sut = new VendingMachine();

            int denominationType = 5;
            int amount = 10;

            int temp = sut.CustomerWallet;
            sut.InsertMoney(denominationType, amount);

            Assert.Equal(denominationType * amount, sut.CustomerWallet);
        }

        [Fact]
        public void NotAcceptInvalidDenomination()
        {
            VendingMachine sut = new VendingMachine();

            int denominationType = 3;
            int amount = 10;

            int temp = sut.CustomerWallet;
            sut.InsertMoney(denominationType, amount);

            Assert.Equal(0, sut.CustomerWallet);
        }

        [Fact]
        public void AcceptPurchaseWithEnoughMoney()
        {
            VendingMachine sut = new VendingMachine();

            sut.InsertMoney(100, 3);
            var moneyBefore = sut.CustomerWallet;
            var product = sut.Purchase("chips");

            Assert.NotNull(product);
            Assert.Equal(moneyBefore - product.Price, sut.CustomerWallet);
        }

        [Fact]
        public void NotAcceptPurchaseWithInsufficientMoney()
        {
            VendingMachine sut = new VendingMachine();

            sut.InsertMoney(1, 4);

            var product = sut.Purchase("chips");

            Assert.Null(product);
        }

        [Fact]
        public void ExamineProductCoke()
        {

            VendingMachine sut = new VendingMachine();
            sut.InsertMoney(1000, 10);
            string descriptionCoke = "Product: coke\tPrice: 15\tDescription: carbonated drink";

            var purchase = sut.Purchase("coke");
            Assert.Equal($"Product: {purchase.ProductName}\tPrice: {purchase.Price}\tDescription: {purchase.Description}", descriptionCoke);
        }

        [Fact]
        public void UseBeverage()
        {

            VendingMachine sut = new VendingMachine();
            sut.InsertMoney(1000, 10);

            var purchase = sut.Purchase("coke");
            string useDrink = $"You drink the {purchase.ProductName}. That was refreshing!";
            Assert.Equal(purchase.Use(), useDrink);
        }

        [Fact]
        public void UseFood()
        {

            VendingMachine sut = new VendingMachine();
            sut.InsertMoney(1000, 1);


            var purchase = sut.Purchase("pizza slice");
            string useFood = $"You eat the {purchase.ProductName}. So tasty!";
            Assert.Equal(purchase.Use(), useFood);
        }

        [Fact]
        public void UseSnacks()
        {

            VendingMachine sut = new VendingMachine();
            sut.InsertMoney(1000, 1);


            var purchase = sut.Purchase("chips");
            string useSnacks = $"You eat the {purchase.ProductName}. That was nice!";
            Assert.Equal(purchase.Use(), useSnacks);
        }

        [Fact]
        public void EndTransaction_5000()
        {
            //Set up
            VendingMachine vendingMachine = new VendingMachine();

            int denominationType = 1000;
            int amount = 5;
            int[] expectedReturn = new[] { 0, 0, 0, 0, 0, 0, 0, 5 };

            vendingMachine.InsertMoney(denominationType, amount);

            Assert.Equal(expectedReturn, vendingMachine.EndTransaction());

        }

        [Fact]
        public void EndTransaction3567()
        {
            VendingMachine sut = new VendingMachine();

            int[] expectedReturn = new[] { 2, 1, 1, 0, 1, 0, 1, 3 };

            sut.InsertMoney(1000, 3);
            sut.InsertMoney(500, 1);
            sut.InsertMoney(50, 1);
            sut.InsertMoney(10, 1);
            sut.InsertMoney(5, 1);
            sut.InsertMoney(1, 2);

            Assert.Equal(expectedReturn, sut.EndTransaction());

        }
    }
}
