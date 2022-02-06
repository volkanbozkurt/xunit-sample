using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitSample.Calculation
{
    public class CalculatorFixture : IDisposable
    {
        public Calculator Calculator => new Calculator();

        public void Dispose()
        {
            //Clean
        }
    }
}
