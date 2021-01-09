using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        //        •	Grams = 250
        private const double CakeGrams = 250;
        //•	Calories = 1000
        private const double CakeCalories = 1000;
        //•	CakePrice = 5
        private const decimal CakePrice = 5m;


        public Cake(string name) 
            : base(name, CakePrice, CakeGrams, CakeCalories)
        {
        }
    }
}
