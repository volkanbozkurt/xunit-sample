using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitSample.Calculation.Tests
{
    public class CustomerFixture : IDisposable
    {
        public Customer Customer => new Customer();

        public void Dispose()
        {
            //Clean
        }
    }
}
