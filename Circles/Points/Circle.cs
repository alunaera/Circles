using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Circles
{
    public class Circle
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public Color Color { get; private set; }
        public SolidBrush Brush { get; private set; }

        private int Radius;
        private double Weight;
        private double VectorX;
        private double VectorY;

        public Circle(int lowBorderX, int lowBorderY, int highBorderX, int highBorderY)
        {
            this.Radius = MainForm.rnd.Next(5, 10);
            this.Width = this.Radius * 2;
            SetRandomColor();
            this.Weight = Math.PI * Math.Pow(Radius, 2) * ColorWeightModifiers(this.Color);

            this.VectorX = MainForm.rnd.Next(500, 600) / this.Weight;
            this.VectorY = MainForm.rnd.Next(500, 600) / this.Weight;
            this.X = MainForm.rnd.Next(lowBorderX, highBorderX);
            this.Y = MainForm.rnd.Next(lowBorderY, highBorderY);

            this.Brush = new SolidBrush(this.Color);
        }
        private void SetRandomColor()
        {
            switch (MainForm.rnd.Next(1, 8))
            {
                case 1:
                    this.Color = Color.Red;
                    break;
                case 2:
                    this.Color = Color.Orange;
                    break;
                case 3:
                    this.Color = Color.Yellow;
                    break;
                case 4:
                    this.Color = Color.LightBlue;
                    break;
                case 5:
                    this.Color = Color.Blue;
                    break;
                case 6:
                    this.Color = Color.Green;
                    break;
                case 7:
                    this.Color = Color.Violet;
                    break;
                default:
                    break;
            }
        }
        private double ColorWeightModifiers(Color color)
        {
            Dictionary<Color, double> dictionary = new Dictionary<Color, double>();
            dictionary[Color.Red] = 1.15;
            dictionary[Color.Orange] = 0.95;
            dictionary[Color.Yellow] = 1.2;
            dictionary[Color.LightBlue] = 0.8;
            dictionary[Color.Blue] = 1.35;
            dictionary[Color.Green] = 1;
            dictionary[Color.Violet] = 1.4;

            return dictionary[color];
        }

        public void Update(Rectangle box)
        {
            this.X += (int)this.VectorX;
            this.Y += (int)this.VectorY;

            if ((this.X + this.VectorX) >= box.Right)
            {
                this.X = box.Right;
                this.VectorX = -this.VectorX;
            }

            if ((this.Y + this.VectorY) >= box.Bottom)
            {
                this.Y = box.Bottom;
                this.VectorY = -this.VectorY;
            }

            if ((this.X + this.VectorX) < box.Left)
            {
                this.X = box.Left;
                this.VectorX = -this.VectorX;
            }

            if ((this.Y + this.VectorY) < box.Top)
            {
                this.Y = box.Top;
                this.VectorY = -this.VectorY;
            }
        }
    }
}
