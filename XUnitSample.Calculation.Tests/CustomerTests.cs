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
    public class CustomerTests
    {
        private readonly CustomerFixture _customerFixture;

        public CustomerTests(CustomerFixture customerFixture)
        {
            _customerFixture = customerFixture;
        }

        [Fact]
        public void Name_ShouldNotBeNullOrEmpty()
        {
            var customer = _customerFixture.Customer;
            Assert.False(string.IsNullOrEmpty(customer.Name));
        }

        [Fact]
        public void Age_CheckIfLegitForDiscount()
        {
            var customer = _customerFixture.Customer;
            Assert.InRange(customer.Age, 25, 45);
        }

        [Fact]
        public void GetOrderCountByUsername_ThrowsAnArgumentExceptionWhenUsernameIsNull()
        {
            var customer = _customerFixture.Customer;
            Assert.Throws<ArgumentException>(() => customer.GetOrderCountByUsername(null));
        }

        [Fact]
        public void GetOrderCountByUsername_ThrowsAnArgumentExceptionWhenUsernameIsEmpty()
        {
            var customer = _customerFixture.Customer;
            Assert.Throws<ArgumentException>(() => customer.GetOrderCountByUsername(""));
        }

        [Fact]
        public void CreateInstance_WhenOrderCountIsGreaterThanAHundred_ReturnsLoyalCustomer()
        {
            var customer = CustomerFactory.CreateInstance(101);
            Assert.IsType<LoyalCustomer>(customer);
        }

        [Fact]
        public void CreateInstance_WhenOrderCountIsNotGreaterThanAHundred_ReturnsCustomer()
        {
            var customer = CustomerFactory.CreateInstance(100);
            Assert.IsType<Customer>(customer);
        }
    }
}
