using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitSample.Calculation.Tests
{
    public class CustomerTest
    {
        [Fact]
        public void Name_ShouldNotBeNullOrEmpty()
        {
            var customer = new Customer();
            Assert.False(string.IsNullOrEmpty(customer.Name));
        }

        [Fact]
        public void Age_CheckIfLegitForDiscount()
        {
            var customer = new Customer();
            Assert.InRange(customer.Age, 25, 45);
        }

        [Fact]
        public void GetOrderCountByUsername_ThrowsAnArgumentExceptionWhenUsernameIsNull()
        {
            var customer = new Customer();
            Assert.Throws<ArgumentException>(() => customer.GetOrderCountByUsername(null));
        }

        [Fact]
        public void GetOrderCountByUsername_ThrowsAnArgumentExceptionWhenUsernameIsEmpty()
        {
            var customer = new Customer();
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
