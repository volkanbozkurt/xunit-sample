using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitSample.Calculation.Tests
{
    public static class TestDataShare
    {
        public static IEnumerable<object[]> OddOrEvenData
        {
            get
            {
                yield return new object[] { 0, false };
                yield return new object[] { 1, true };
                yield return new object[] { 2, false };
                yield return new object[] { 99, true };
                yield return new object[] { 200, false };
                yield return new object[] { 2005, true };
            }
        }
    }
}
