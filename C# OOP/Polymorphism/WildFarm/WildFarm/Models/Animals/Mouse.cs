﻿using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplyer => 0.1;

        public override ICollection<Type> PrefferedFood => new List<Type>() { typeof(Vegetable), typeof(Fruit) };

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
