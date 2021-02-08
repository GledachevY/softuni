using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Direction direction;
        private Snake snake;
        private Wall wall;
        private int sleepTime = 100;
        private Point[] directionpoints;

        public Engine(Snake snake,Wall wall)
        {
            this.wall = wall;
            this.snake = snake;
            this.direction = Direction.Right;
            this.directionpoints = new Point[]
                {
                    new Point(1,0),
                     new Point(-1,0),
                      new Point(0,1),
                       new Point(0,-1),
                };
        }
        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNexDirection();
                }

              var cnaMove =  this.snake.isMoving(this.directionpoints[(int)this.direction]);

                if (!cnaMove)
                {
                    File.AppendAllText("../../../DataBase/scores.txt",$"Yavor - {this.snake.Lenght} - {DateTime.Now:d}{Environment.NewLine}");
                    var rsults = File.ReadAllText("../../../DataBase/scores.txt");

                    Console.SetCursorPosition(0, this.wall.TopY + 2);
                    Console.WriteLine(rsults);
                    Console.WriteLine("Oh nooooo");
                    Thread.Sleep(2000);
                    StartUp.Main();
                }
                Thread.Sleep(sleepTime);
            }
        }

        private void GetNexDirection()
        {
            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.LeftArrow)
            {
                if (this.direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (input.Key == ConsoleKey.RightArrow)
            {
                if (this.direction != Direction.Left)
                {
                    direction = Direction.Right;
                }

            }
            else if (input.Key == ConsoleKey.UpArrow)
            {
                if (this.direction != Direction.Down)
                {
                    direction = Direction.Up;
                }

            }
            else if (input.Key == ConsoleKey.DownArrow)
            {
                if (this.direction != Direction.Up)
                {
                    direction = Direction.Down;
                }

            }
        }
    }
}