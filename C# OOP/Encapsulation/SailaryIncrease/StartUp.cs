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
                decimal salary = decimal.Parse(input[3]);
                Person person = new Person(fName, lName, age,salary);
                persons.Add(person);
            }


            decimal percent = decimal.Parse(Console.ReadLine());
            persons.ForEach(p => p.IncreaseSalary(percent));
            persons.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
