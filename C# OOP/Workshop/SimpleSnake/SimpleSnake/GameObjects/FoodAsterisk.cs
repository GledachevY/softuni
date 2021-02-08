using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
   public class FoodAsterisk : Food
    {
        private const char FoodSymbol = '*';
        private const int Points = 3;
        public FoodAsterisk(Wall wall)
            : base(wall, FoodSymbol, Points)
        {
        }
    }
}
