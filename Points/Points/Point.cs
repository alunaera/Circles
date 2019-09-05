using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Color;
        
       
        public Point(int X, int Y)
        {
            Random rnd = new Random();
            this.Width = rnd.Next(5, 15);
            this.Weight = Width * Width / 7;
            this.VectorX = rnd.Next(-10, 10)-Weight;
            this.VectorY = rnd.Next(-10, 10)-Weight;
            this.x = X;
            this.y = Y;
            this.BumpCount = 0;
            this.TimeLife = 0;
            AddColor();
        }
        private void AddColor()
        {
            Random rnd = new Random();
            switch (rnd.Next(1, 7))
            {
                case 1: { this.Color = "Red"; break; }
                case 2: { this.Color = "Orange"; break; }
                case 3: { this.Color = "Yellow"; break; }
                case 4: { this.Color = "LightBlue"; break; }
                case 5: { this.Color = "Blue"; break; }
                case 6: { this.Color = "Green"; break; }
                case 7: { this.Color = "Violet"; break; }
                default: break;
            }
        }

        public void Way(int Width, int Height, int locX, int locY)
        {
            if ((this.x + this.VectorX) >= Width)
            {
                this.x = Width;
                this.VectorX = -this.VectorX;
                this.BumpCount++;
            }

            if ((this.y + this.VectorY) >= Height)
            {
                this.y = Height;
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
