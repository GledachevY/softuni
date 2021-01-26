using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    class Person
    {
        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }
        
        [MyRange(12, 90)]
        public int Age { get; set; }
        [MyRequired]
        public string FullName { get; set; }
    }
}
