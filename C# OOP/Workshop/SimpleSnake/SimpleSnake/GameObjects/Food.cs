using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        private readonly Random random;
        private  Wall wall;

        protected Food(Wall wall, char symbol, int foodPoints)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.Symbol = symbol;
            this.FoodPoints = foodPoints;
            this.random = new Random();


        }

        public char Symbol { get; }

        public int FoodPoints { get; }

        public void SetRandomPosition(Queue<Point> snake)
        {
            this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
            this.TopY = this.random.Next(2, this.wall.TopY - 3);

            var isPartOfSnake = snake.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);

            while (isPartOfSnake)
            {
                this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
                this.TopY = this.random.Next(2, this.wall.TopY - 2);

                isPartOfSnake = snake.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;

            this.Draw(this.LeftX, this.TopY, this.Symbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool isFoofPoint(Point snake) => this.LeftX == snake.LeftX &&
            this.TopY == snake.TopY;
    }
}
