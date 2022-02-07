using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitSample.Calculation.Tests
{
    //For every test method, xUnit creates an instance of our test class to execute methods in parallel.

    //With the same name of a Collection attribute, we make our test classes related and they will be executed as one instance.
    //In this example, CustomerDetailTests and CustomerTests will be executed as one instance.
    [Collection("CustomerInfo")]
    public class CustomerDetailTests
    {
        private readonly CustomerFixture _customerFixture;

        public CustomerDetailTests(CustomerFixture customerFixture)
        {
            _customerFixture = customerFixture;
        }

        [Fact]
        public void GetFullName_GivenFirstAndLastName_ReturnsFullName()
        {
            var customer = _customerFixture.Customer;
            var actual = customer.GetFullName("Volkan", "Bozkurt");
            Assert.Equal("Volkan Bozkurt", actual);
        }
    }
}
