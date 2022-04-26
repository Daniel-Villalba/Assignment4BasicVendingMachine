using System;

namespace Assignment4BasicVendingMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();
            bool endApp = false;

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Welcome to the Basic Vending Machine in C#\r");
            Console.WriteLine("------------------------------------------\n");


            while (!endApp)
            {
                Console.WriteLine($"\nAvailible money in the machine: {vendingMachine.CustomerWallet}\n");
                vendingMachine.ShowAll();


                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Put money in the machine");
                Console.WriteLine("2. Buy a Coke");
                Console.WriteLine("3. Buy a Pizza Slice");
                Console.WriteLine("4. Buy Chips");
                Console.WriteLine("0. Exit and get your change back");
                Console.WriteLine("\nYour selection?");

                char selection = Console.ReadKey().KeyChar;
                char answerUsing;

                switch (selection)
                {
                    case '1':
                        ShowAvailableDenom();
                        int selDenom = GetSelectedDenom();
                        int amountDenom = GetAmountDenom();
                        vendingMachine.InsertMoney(selDenom, amountDenom);
                        break;

                    case '2':
                        var purchase = vendingMachine.Purchase("coke");
                        if (purchase != null)
                        {
                            ShowQuestionOfUsing();
                            answerUsing = GetUsingChoise();

                            if (answerUsing == 'y')
                                Console.WriteLine("\n\n" + purchase.Use());
                        }
                        break;

                    case '3':
                        var purchase2 = vendingMachine.Purchase("pizza slice");
                        if (purchase2 != null)
                        {
                            ShowQuestionOfUsing();
                            answerUsing = GetUsingChoise();

                            if (answerUsing == 'y')
                                Console.WriteLine("\n\n" + purchase2.Use());
                        }
                        break;

                    case '4':
                        var purchase3 = vendingMachine.Purchase("chips");
                        if (purchase3 != null)
                        {
                            ShowQuestionOfUsing();
                            answerUsing = GetUsingChoise();

                            if (answerUsing == 'y')
                                Console.WriteLine("\n\n" + purchase3.Use());
                        }
                        break;

                    case '0':
                        Console.WriteLine("\nThank you for using the Basic Vending Machine!!" +
                            "\nHere is your change in correct denominations:\n ");
                        vendingMachine.EndTransaction();
                        endApp = true;
                        break;
                    default:
                        Console.WriteLine("\nNot a valid selection, please try again");
                        break;
                }
            }
        }
        public static void ShowAvailableDenom()
        {
            Console.WriteLine("\nSelect what kind of denomination you would like to insert:");
            Console.WriteLine("1.\t1kr");
            Console.WriteLine("2.\t5kr");
            Console.WriteLine("3.\t10kr");
            Console.WriteLine("4.\t20kr");
            Console.WriteLine("5.\t50kr");
            Console.WriteLine("6.\t100kr");
            Console.WriteLine("7.\t500kr");
            Console.WriteLine("8.\t1000kr");
        }
        public static int GetSelectedDenom()
        {
            int selectedDenom = 0;
            bool keepGoning = true;

            while (keepGoning)
            {
                Console.Write("\nYour selection: ");
                char c = Console.ReadKey().KeyChar;

                switch (c)
                {
                    case '1':
                        selectedDenom = 1;
                        keepGoning = false;
                        break;
                    case '2':
                        selectedDenom = 5;
                        keepGoning = false;
                        break;
                    case '3':
                        selectedDenom = 10;
                        keepGoning = false;
                        break;
                    case '4':
                        selectedDenom = 20;
                        keepGoning = false;
                        break;
                    case '5':
                        selectedDenom = 50;
                        keepGoning = false;
                        break;
                    case '6':
                        selectedDenom = 100;
                        keepGoning = false;
                        break;
                    case '7':
                        selectedDenom = 500;
                        keepGoning = false;
                        break;
                    case '8':
                        selectedDenom = 1000;
                        keepGoning = false;
                        break;
                    default:
                        Console.WriteLine("\nNot a valid selection, please try again");
                        break;
                }
            }
            return selectedDenom;
        }
        public static int GetAmountDenom()
        {
            int amount = 0;
            string numInput;
            Console.WriteLine("\nHow many of the selected denomination would you like to insert?");
            numInput = Console.ReadLine();
            while (!int.TryParse(numInput, out amount))
            {
                Console.Write("This is not valid input. Please enter a number: ");
                numInput = Console.ReadLine();
            }
            return amount;

        }
        public static void ShowQuestionOfUsing()
        {
            Console.WriteLine("\nWould you like to use the product you just bought?");
            Console.WriteLine("Press y if you want to use the product or any other key otherwise: ");
        }

        public static char GetUsingChoise()
        {
            char c = Console.ReadKey().KeyChar;
            return c;
        }
    }
}
