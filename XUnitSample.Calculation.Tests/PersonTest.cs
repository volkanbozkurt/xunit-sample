using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitSample.Calculation.Tests
{
    public class PersonTest
    {
        [Fact]
        public void MakeFullName_GivenTwoStrings_ReturnsConcatenatedString()
        {
            var person = new Person();
            var result = person.MakeFullName("Volkan", "Bozkurt");
            Assert.Equal("Volkan Bozkurt", result);
        }

        [Fact]
        public void MakeFullName_AlwaysReturnsValue()
        {
            var person = new Person();
            var result = person.MakeFullName("", "");
            Assert.False(string.IsNullOrEmpty(result));
        }

        [Fact]
        public void NickName_MustBeNullWhenCreatingNewPersonInstance()
        {
            var person = new Person();
            Assert.Null(person.NickName);
        }
    }
}
