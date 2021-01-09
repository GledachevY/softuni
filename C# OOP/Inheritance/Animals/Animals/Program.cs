using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> CollectionOfAnimals = new List<Animal>();
            string animalType = Console.ReadLine();
            while (animalType != "Beast!")
            {
               
                string[] animalSpec = Console.ReadLine().Split().ToArray();
                string name = animalSpec[0];
                int age = int.Parse(animalSpec[1]);
                string gender = animalSpec[2];
                
                switch (animalType)
                {
                    case "Dog":
                        Animal dog = new Dog(name, age, gender);
                        CollectionOfAnimals.Add(dog);
                        break;
                    case "Cat":
                        Animal cat = new Cat(name, age, gender);
                        CollectionOfAnimals.Add(cat);
                        break;
                    case "Frog":
                        Animal frog = new Frog(name, age, gender);
                        CollectionOfAnimals.Add(frog);
                        break;
                    case "Kitten":
                        Animal kitten = new Kitten(name, age);
                        CollectionOfAnimals.Add(kitten);
                        break;
                    case "Tomcat":
                        Animal tomcat = new Tomcat(name, age);
                        CollectionOfAnimals.Add(tomcat);
                        break;

                }

                animalType = Console.ReadLine();
            }
            foreach(var animalToPrint in CollectionOfAnimals)
            {
                Console.WriteLine(animalToPrint.TypeOfAnimal());
                Console.WriteLine($"{animalToPrint.Name} {animalToPrint.Age} {animalToPrint.Gender}");
                Console.WriteLine(animalToPrint.ProduceSound());
                
            }


        }
    }
}
