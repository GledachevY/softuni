using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string TomcatGender = "male";
        public Tomcat(string name, int age) 
            : base(name, age, TomcatGender)
        {
        }
        public override string ProduceSound()
        {
            return "MEOW";
        }
        public override string TypeOfAnimal()
        {
            return "Tomcat";
        }
    }
}
