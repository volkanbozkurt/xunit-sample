using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitSample.Calculation
{
    public class Person
    {
        public string NickName { get; set; }

        public string MakeFullName(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }
    }
}
