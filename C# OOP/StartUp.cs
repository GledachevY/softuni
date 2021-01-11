using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();
            for(int  i = 1; i <= lines; i++)
            {
                string[] input = Console.ReadLine().Split();
                string fName = input[0];
                string lName = input[1];
                int age = int.Parse(input[2]);
                Person person = new Person(fName, lName, age);
                persons.Add(person);
            }
            var orderedPersons = persons.OrderBy(p => p.FirstName).ThenBy(p => p.Age);
            foreach(var p in orderedPersons)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}
