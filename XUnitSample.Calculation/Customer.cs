using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitSample.Calculation
{
    public class Customer
    {
        public string Name => "Volkan";
        public int Age => 30;

        public int GetOrderCountByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException();

            return 100;
        }
    }
}
