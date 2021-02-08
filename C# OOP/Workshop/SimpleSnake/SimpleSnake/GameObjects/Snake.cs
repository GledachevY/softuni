using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake : Point
    {
        private const char SnakeSymbol = '\u25CF';
        private readonly Queue<Point> snakeElements;
        private readonly Wall wall;
        private readonly Food[] food;

        private readonly int foodIndex = new Random().Next(0, 3);

        public bool IsWallPoint()
        => this.LeftX == 0 || this.TopY == 0 || this.LeftX == this.wall.LeftX
                || this.TopY == this.wall.TopY;

        public Snake(Wall wall, int leftX, int topY)
            : base(leftX, topY)
        {
            snakeElements = new Queue<Point>();
            this.wall = wall;

            this.food = new Food[]
            {
            new FoodAsterisk(this.wall),
            new FoodDollar(this.wall),
            new FoodHash(this.wall)
            };

            this.CreateSnake();

            this.food[this.foodIndex].SetRandomPosition(this.snakeElements);
        }

        public void CreateSnake()
        {
            for (int i = 0; i < 6; i++)
            {
                var point = new Point(this.LeftX + i, this.TopY);
                point.Draw(SnakeSymbol);
                snakeElements.Enqueue(point);

            }
        }
        private void GetNextDirection(Point head, Point directon)
        {
            this.LeftX = head.LeftX + directon.LeftX;
            this.TopY = head.TopY + directon.TopY;
        }

        public int Lenght
        => this.snakeElements.Count;

        public bool isMoving(Point direction)
        {
            var currentSnakeHead = this.snakeElements.Last();

            GetNextDirection(currentSnakeHead, direction);

            if (IsWallPoint())
            {
                return false;
            }


            if (IsPointOfSnake())
            {
                return false;
            }

            Point newHead = CreateNewHead();

            if (this.food[foodIndex].isFoofPoint(newHead))
            {
                this.Eat(direction, newHead);
            }

            RemoveTail();

            return true;
        }

        private void RemoveTail()
        {
            var tail = this.snakeElements.Dequeue();
            tail.Draw(' ');
        }

        private Point CreateNewHead()
        {
            var newHead = new Point(this.LeftX, this.TopY);
            newHead.Draw(SnakeSymbol);
            this.snakeElements.Enqueue(newHead);
            return newHead;
        }

        private void Eat(Point direction, Point newHead)
        {
            for (int i = 0; i < this.food[foodIndex].FoodPoints; i++)
            {
                this.GetNextDirection(newHead, direction);
                newHead = new Point(this.LeftX, this.TopY);
                newHead.Draw(SnakeSymbol);
                this.snakeElements.Enqueue(newHead);
            }
            this.food[this.foodIndex].SetRandomPosition(this.snakeElements);

        }

        private bool IsPointOfSnake()
        {
            return this.snakeElements.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
        }
    }
}
