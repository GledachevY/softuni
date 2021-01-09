using System;

namespace NeedForSpeed
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle lambo = new SportCar(200, 80);
            Console.WriteLine(lambo.GetType());
        }
    }
}
