using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace XUnitSample.Calculation.Tests
{
    public class OddOrEvenDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
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
