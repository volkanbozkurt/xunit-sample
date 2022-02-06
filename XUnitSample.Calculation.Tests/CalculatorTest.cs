using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitSample.Calculation.Tests
{
    /*
     xUnit.Net’te üretilecek olan instance’ların üretim maliyetini düşürebilmek için ilgili sınıftan tek bir nesne üretilmeli
     ve tüm birim testlerinde o nesne kullanılmalıdır. Bunun için ‘IClassFixture’ interface’i kullanılabilir.
     */
    public class CalculatorTest : IClassFixture<CalculatorFixture>
    {
        private readonly CalculatorFixture _calculatorFixture;

        public CalculatorTest(CalculatorFixture calculatorFixture)
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
