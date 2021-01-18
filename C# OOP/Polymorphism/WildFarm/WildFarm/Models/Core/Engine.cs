using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Core
{
    class Engine : IEngine
    {
        private readonly ICollection<Animal> animals;

        private readonly AnimalFactory animalFactory;
        private readonly FoodFactory foodFactory;
        public Engine()
        {
            this.animals = new HashSet<Animal>();
            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
        }
        public void Run()
        {

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string animalType = animalArgs[0];
                string name = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);
                string[] args = animalArgs.Skip(3).ToArray();

                Animal animal = null;
                try
                {
                    animal = this.animalFactory.CreateAnimal(animalType, name, weight, args);
                    this.animals.Add(animal);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                string[] foodArgs = Console.ReadLine().Split();
                string foodType = foodArgs[0];
                int foodQuontity = int.Parse(foodArgs[1]);

                try
                {
                    Food food = this.foodFactory.CreateFood(foodType, foodQuontity);
                    animal.Feed(food);
                }
                catch(InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            foreach(var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
