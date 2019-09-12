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
        public int X { get; set; }
        public int Y { get; set; }
        public double VectorX { get; set; }
        public double VectorY { get; set; }
        public int Width { get; set; }
        public double Weight { get; set; }
        public Color Color { get; set; }

        Random rnd = new Random();

        public Point(int borderX, int borderY)
        {
            this.Width = rnd.Next(5, 15);
            AddColor();
            this.Weight = Math.PI * Math.Pow(Width, 2) / 4;
            this.VectorX = rnd.Next(100, 300) / this.Weight;
            this.VectorY = rnd.Next(100, 300) / this.Weight;
            this.X = rnd.Next(0, borderX);
            this.Y = rnd.Next(0, borderY);
        }
        private void AddColor()
        {
            switch (rnd.Next(1, 8))
            {
                case 1:
                    {
                        this.Color = Color.Red;
                        this.Weight *= 1.15;
                        break;
                    }
                case 2:
                    {
                        this.Color = Color.Orange;
                        this.Weight *= 0.95;
                        break;
                    }
                case 3:
                    {
                        this.Color = Color.Yellow;
                        this.Weight *= 1.2;
                        break;
                    }
                case 4:
                    {
                        this.Color = Color.LightBlue;
                        this.Weight *= 0.8;
                        break;
                    }
                case 5:
                    {
                        this.Color = Color.Blue;
                        this.Weight *= 1.35;
                        break;
                    }
                case 6:
                    {
                        this.Color = Color.Green;
                        this.Weight *= 1;
                        break;
                    }
                case 7:
                    {
                        this.Color = Color.Violet;
                        this.Weight *= 1.4;
                        break;
                    }
                default:
                    break;
            }
        }

        public void Update(int boxWidth, int boxHeight, int boxLocX, int boxLocY)
        {
            if ((this.X + this.VectorX) >= boxWidth)
            {
                this.X = boxWidth;
                this.VectorX = -this.VectorX;
            }

            if ((this.Y + this.VectorY) >= boxHeight)
            {
                this.Y = boxHeight;
                this.VectorY = -this.VectorY;
            }

            if ((this.X + this.VectorX) < boxLocX)
            {
                this.X = boxLocX;
                this.VectorX = -this.VectorX;
            }

            if ((this.Y + this.VectorY) < boxLocY)
            {
                this.Y = boxLocY;
                this.VectorY = -this.VectorY;
            }

            this.X += (int)this.VectorX;
            this.Y += (int)this.VectorY;
        }

    }
}
