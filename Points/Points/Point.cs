using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Points
{
    public class Point
    {
        public int Id;
        public int x;
        public int y;
        public int VectorX;
        public int VectorY;
        public int Width;
        public int BumpCount;
        public int TimeLife;
        public int Weight;
        public Color Color;
        Random rnd = new Random();

        public Point(int x, int y)
        {
            this.Width = rnd.Next(5, 15);
            this.Weight = Width / 3;
            this.VectorX = AddVector();
            this.VectorY = AddVector();
            this.x = x;
            this.y = y;
            this.BumpCount = 0;
            this.TimeLife = 0;
            AddColor();
        }
        private void AddColor()
        {
            switch (rnd.Next(1, 7))
            {
                case 1: { this.Color = Color.Red; break; }
                case 2: { this.Color = Color.Orange; break; }
                case 3: { this.Color = Color.Yellow; break; }
                case 4: { this.Color = Color.LightBlue; break; }
                case 5: { this.Color = Color.Blue; break; }
                case 6: { this.Color = Color.Green; break; }
                case 7: { this.Color = Color.Violet; break; }
                default: break;
            }
        }

        private int AddVector()
        {
            int speed = rnd.Next(-10, 10);
            if (speed < 0)
                speed += this.Weight;
            else
                speed -= this.Weight;
            return speed;
        }

        public void UpdateWay(int width, int height, int locX, int locY)
        {
            if ((this.x + this.VectorX) >= width)
            {
                this.x = width;
                this.VectorX = -this.VectorX;
                this.BumpCount++;
            }

            if ((this.y + this.VectorY) >= height)
            {
                this.y = height;
                this.VectorY = -this.VectorY;
                this.BumpCount++;
            }

            if ((this.x + this.VectorX) < locX)
            {
                this.x = locX;
                this.VectorX = -this.VectorX;
                this.BumpCount++;
            }

            if ((this.y + this.VectorY) < locY)
            {
                this.y = locY;
                this.VectorY = -this.VectorY;
                this.BumpCount++;
            }

            this.x += this.VectorX;
            this.y += this.VectorY;
        }

    }
}
