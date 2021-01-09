﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string KittenGender = "female";
        public Kitten(string name, int age)
            : base(name, age, KittenGender)
        {
        }
        public override string ProduceSound()
        {
            return "Meow";
        }
        public override string TypeOfAnimal()
        {
            return "Kitten";
        }
    }
}
