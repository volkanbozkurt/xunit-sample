using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitSample.Calculation
{
    public class LoyalCustomer : Customer
    {
        public LoyalCustomer()
        {
            Discount = 10;
        }

        public int Discount { get; set; }
    }
}
