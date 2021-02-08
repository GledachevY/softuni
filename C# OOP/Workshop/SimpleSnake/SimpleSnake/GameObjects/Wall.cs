using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    //■
    public class Wall : Point
    {
        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
          
            SetHorizontalLine();
            SetVerticalLine();
        }

        public void SetVerticalLine()
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(0, topY, '■');
            }

            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(this.LeftX, topY, '■');
            }
        }

        public void SetHorizontalLine()
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, 0, '■');
            }

            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, this.TopY - 1, '■');
            }
        }
    }
}
