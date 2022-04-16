using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitSample.Calculation.Tests
{
    //For every test method, xUnit creates an instance of our test class to execute methods in parallel.
    /*
     xUnit.Net’te üretilecek olan instance’ların üretim maliyetini düşürebilmek için ilgili sınıftan tek bir nesne üretilmeli
     ve tüm birim testlerinde o nesne kullanılmalıdır. Bunun için ‘IClassFixture’ interface’i kullanılabilir.
     */
    public class CalculatorTests : IClassFixture<CalculatorFixture>
    {
        private readonly CalculatorFixture _calculatorFixture;

        public CalculatorTests(CalculatorFixture calculatorFixture)
        {
            _calculatorFixture = calculatorFixture;
        }

        //The [Fact] attribute declares a test method that's run by the test runner.
        [Fact]
        public void AddInt_GivenTwoIntValues_ReturnsSum()
        {
            var calc = _calculatorFixture.Calculator;
            var result = calc.AddInt(1, 2);
            //Assert contains various static methods that are used to verify that conditions are met during the process of running tests.
            Assert.Equal(3, result);
        }

        [Fact]
        public void AddDouble_GivenTwoDoubleValues_ReturnsSum()
        {
            var calc = _calculatorFixture.Calculator;
            var result = calc.AddDouble(1.2, 3.5);
            Assert.Equal(4.7, result);
        }

        //With [Theory] and [InlineData] attribute, xUnit executes the test method with different input values.
        //So, you do not need to write test methods separately for every input values
        //These input values can only be used for this method. NOT SHAREABLE.
        [Theory]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(2, false)]
        [InlineData(99, true)]
        [InlineData(200, false)]
        [InlineData(2005, true)]
        public void IsOdd_GivenOddValueWithInlineData_ReturnsTrue(int value, bool expected)
        {
            var calc = _calculatorFixture.Calculator;
            var actual = calc.IsOdd(value);
            Assert.Equal(expected, actual);
        }

        //With [Theory] and [MemberData] attribute, xUnit executes the test method with different input values.
        //So, you do not need to write test methods separately for every input values
        //These input values can be used for every methods which apply this attribute. SHAREABLE
        [Theory]
        [MemberData(nameof(TestDataShare.OddOrEvenData), MemberType = typeof(TestDataShare))]
        public void IsOdd_GivenOddValueWithMemberData_ReturnsTrue(int value, bool expected)
        {
            var calc = _calculatorFixture.Calculator;
            var actual = calc.IsOdd(value);
            Assert.Equal(expected, actual);
        }

        //With [Theory] and our Custom Attribute (in here, it is OddOrEvenData as an example),
        //xUnit executes the test method with different input values.
        //So, you do not need to write test methods separately for every input values
        //These input values can be used for every methods which apply this attribute. SHAREABLE
        [Theory]
        [OddOrEvenData]
        public void IsOdd_GivenOddValueWithOurCustomAttribute_ReturnsTrue(int value, bool expected)
        {
            var calc = _calculatorFixture.Calculator;
            var actual = calc.IsOdd(value);
            Assert.Equal(expected, actual);
        }

        [Fact]
        //Trait attribute, test metotlarımızı Test Explorer'da görüntülerken kategorize etmemizi sağlar.
        [Trait("Category", "Fibonacci")]
        public void FibonacciNumbers_DoNotIncludeZero()
        {
            var calc = _calculatorFixture.Calculator;
            Assert.All(calc.FibonacciNumbers, number => Assert.NotEqual(0, number));
        }

        [Fact]
        [Trait("Category", "Fibonacci")]
        public void FibonacciNumbers_IncludeThirteen()
        {
            var calc = _calculatorFixture.Calculator;
            Assert.Contains(13, calc.FibonacciNumbers);
        }

        [Fact]
        [Trait("Category", "Fibonacci")]
        public void FibonacciNumbers_DoNotIncludeFour()
        {
            var calc = _calculatorFixture.Calculator;
            Assert.DoesNotContain(4, calc.FibonacciNumbers);
        }
    }
}
