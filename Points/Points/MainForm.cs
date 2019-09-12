using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Points
{

    public partial class MainForm : Form
    {
        List<Point> points = new List<Point>();
        Random rnd = new Random();
        Pen pen = new Pen(Color.Red, 0);
        public MainForm()
        {
            InitializeComponent();
            this.Paint += OnPaint;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            foreach (var myPoint in points)
            {
                pen.Color = myPoint.Color;
                pen.Width = myPoint.Width;
                e.Graphics.DrawEllipse(pen, myPoint.X, myPoint.Y, myPoint.Width, myPoint.Width);
            }
        }
         
        private void Timer1_Tick(object sender, EventArgs e)
        {
            foreach (var myPoint in points)
            {
                myPoint.Update(Box.Width, Box.Height, Box.Location.X, Box.Location.Y);
            }

            label1.Text = "Шаров: " + points.Count;
            Refresh();
        }

        private void Start_Click(object sender, EventArgs e)
        {     
            timer1.Enabled = !timer1.Enabled;
            if (timer1.Enabled)
            {
                Start.Text = "Стоп";
                addPoint.Visible = true;
                label1.Visible = true;
            }
            else
            {
                Start.Text = "Старт";
                addPoint.Visible = false;
                label1.Visible = false;
            }
        }

        private void AddPoint_Click(object sender, EventArgs e)
        {
                Point point = new Point(Box.Location.X, Box.Location.Y);
                points.Add(point);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
