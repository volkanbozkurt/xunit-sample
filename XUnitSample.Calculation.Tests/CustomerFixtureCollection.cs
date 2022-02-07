using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitSample.Calculation.Tests
{
    //It is a container class. It is used as markup
    //This CustomerFixture will be applied to all test classes which are member of this CustomerInfo collection (CustomerDetailTests and CustomerTests)
    [CollectionDefinition("CustomerInfo")]
    public class CustomerFixtureCollection : ICollectionFixture<CustomerFixture>
    {
    }
}
