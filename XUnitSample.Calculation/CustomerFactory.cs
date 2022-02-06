using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitSample.Calculation
{
    public static class CustomerFactory
    {
        public static Customer CreateInstance(int orderCount)
        {
            if (orderCount <= 100)
                return new Customer();
            else
                return new LoyalCustomer();
        }
    }
}
