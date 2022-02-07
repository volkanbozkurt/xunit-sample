using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitSample.Calculation.Tests
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
