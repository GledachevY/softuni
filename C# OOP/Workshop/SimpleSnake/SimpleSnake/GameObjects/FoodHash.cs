using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class FoodHash : Food
    {
        private const char FoodSymbol = '#';
        private const int Points = 1;
        public FoodHash(Wall wall ) 
            : base(wall, FoodSymbol, Points)
        {
        }
    }
}
