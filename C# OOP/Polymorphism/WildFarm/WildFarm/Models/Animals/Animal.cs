using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal, IFeedable, IProduceSoundable
    {
        private const string INVALID_FOOD = "{0} does not eat {1}!";
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            Console.WriteLine(this.ProduceSound());
        }
        public int FoodEaten { get; set; }

        public abstract double WeightMultiplyer { get; }

        public abstract ICollection<Type> PrefferedFood { get; }

        public string Name { get; }
        public double Weight { get; set; }

        public void Feed(IFood food)
        {
            if (!this.PrefferedFood.Contains(food.GetType()))
            {
                throw new InvalidOperationException(string.Format(INVALID_FOOD, this.GetType().Name, food.GetType().Name));
            }
            this.Weight += food.Quantity * this.WeightMultiplyer;
            this.FoodEaten += food.Quantity;
        }

        public abstract string ProduceSound();

    }
}
