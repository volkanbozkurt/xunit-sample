using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitSample.Calculation
{
    public class Calculator
    {
        public List<int> FibonacciNumbers => new List<int> { 1, 1, 2, 3, 5, 8, 13 };

        public Calculator()
        {
            Console.WriteLine("Constructor was executed!!");
        }

        public int AddInt(int a, int b)
        {
            return a + b;
        }

        public double AddDouble(double a, double b)
        {
            return a + b;
        }
    }
}
