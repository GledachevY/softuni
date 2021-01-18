using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models;
using WildFarm.Models.Animals;

namespace WildFarm
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(string typeStr, string name, double weight, string[] args)
        {
            Animal animal = null;
            if (args.Length == 1)
            {
                bool isBird = double.TryParse(args[0], out double wingSize);
                if (isBird)
                {
                    if (typeStr == "Owl")
                    {
                        animal = new Owl(name, weight, wingSize);
                        animal.ProduceSound();
                    }
                    else
                    {
                        animal = new Hen(name, weight, wingSize);
                        animal.ProduceSound();
                    }
                }
                else
                {
                    string livingRegion = args[0];
                    if (typeStr == "Mouse")
                    {
                        animal = new Mouse(name, weight, livingRegion);
                        animal.ProduceSound();
                    }
                    else
                    {
                        animal = new Dog(name, weight, livingRegion);
                        animal.ProduceSound();
                    }
                }


            }
            else
            {
                string livingRegion = args[0];
                string breed = args[1];
                if(typeStr == "Cat")
                {
                    animal = new Cat(name, weight, livingRegion, breed);
                    animal.ProduceSound();
                }
                else
                {
                    animal = new Tiger(name, weight, livingRegion, breed);
                    animal.ProduceSound();
                }
            }
            return animal;
        }
    }
}
