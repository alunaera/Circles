using System;
using System.Collections.Generic;
using System.Drawing;

namespace Circles
{
    public class Circle
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Radius { get; private set; }
        public SolidBrush Brush { get; private set; }

        private double vectorX;
        private double vectorY;
        private static readonly Dictionary<Color, double> colorWeightModifiers = new Dictionary<Color, double>
        {
            [Color.Red] = 1.15,
            [Color.Orange] = 0.95,
            [Color.Yellow] = 1.2,
            [Color.LightBlue] = 0.8,
            [Color.Blue] = 1.35,
            [Color.Green] = 1,
            [Color.Violet] = 1.4
        };
        public Circle(Rectangle rectangle, Random random)
        {
            this.Radius = random.Next(5, 10);
            this.Brush = new SolidBrush(this.GetRandomColor(random));
            double weight = Math.PI * Math.Pow(Radius, 2) * colorWeightModifiers[this.Brush.Color];

            this.vectorX = random.Next(500, 600) / weight;
            this.vectorY = random.Next(500, 600) / weight;
            this.X = random.Next(rectangle.Left, rectangle.Right);
            this.Y = random.Next(rectangle.Top, rectangle.Bottom);
        }
        private Color GetRandomColor(Random random)
        {
            switch (random.Next(1, 8))
            {
                case 1:
                    return Color.Red;
                case 2:
                    return Color.Orange;
                case 3:
                    return Color.Yellow;
                case 4:
                    return Color.LightBlue;
                case 5:
                    return Color.Blue;
                case 6:
                    return Color.Green;
                case 7:
                    return Color.Violet;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public void Update(Rectangle box)
        {
            if (this.X + this.vectorX + 2 * this.Radius > box.Right)
            {
                this.X = box.Right - 2 * this.Radius;
                this.vectorX = -this.vectorX;
            }

            if (this.Y + this.vectorY + 2 * this.Radius > box.Bottom)
            {
                this.Y = box.Bottom - 2 * this.Radius;
                this.vectorY = -this.vectorY;
            }

            if (this.X + this.vectorX < box.Left)
            {
                this.X = box.Left;
                this.vectorX = -this.vectorX;
            }

            if (this.Y + this.vectorY < box.Top)
            {
                this.Y = box.Top;
                this.vectorY = -this.vectorY;
            }

            this.X += (int)this.vectorX;
            this.Y += (int)this.vectorY;
        }
    }
}
