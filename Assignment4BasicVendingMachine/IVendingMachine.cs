using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4BasicVendingMachine
{
    public interface IVendingMachine
    {
        ProductItem Purchase(string productName);
        void ShowAll();
        void InsertMoney(int denominationType, int amount);
        int[] EndTransaction();
    }
}
