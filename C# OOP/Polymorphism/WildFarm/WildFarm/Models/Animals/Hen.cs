using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplyer => 0.35;

        public override ICollection<Type> PrefferedFood => new List<Type>() {typeof(Fruit), typeof(Meat), typeof (Seeds),
            typeof(Vegetable) };

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
