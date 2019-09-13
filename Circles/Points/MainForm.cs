using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Circles
{

    public partial class MainForm : Form
    {
        List<Circle> listOfCircles = new List<Circle>();
        public static Random rnd = new Random();
        public MainForm()
        {
            InitializeComponent();
            this.Paint += OnPaint;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            foreach (var myCircle in listOfCircles)
            {
                e.Graphics.FillEllipse(myCircle.Brush, myCircle.X, myCircle.Y, myCircle.Width, myCircle.Width);
            }
        }
         
        private void Timer1_Tick(object sender, EventArgs e)
        {
            foreach (var myPoint in listOfCircles)
            {
                myPoint.Update(paintBox.DisplayRectangle);
            }

            circleCountLabel.Text = "Шаров: " + listOfCircles.Count;
            Refresh();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {     
            timer1.Enabled = !timer1.Enabled;
            if (timer1.Enabled)
            {
                StartButton.Text = "Стоп";
                addPointButton.Visible = true;
                circleCountLabel.Visible = true;
            }
            else
            {
                StartButton.Text = "Старт";
                addPointButton.Visible = false;
                circleCountLabel.Visible = false;
            }
        }

        private void AddPointButton_Click(object sender, EventArgs e)
        {
                Circle circle = new Circle(paintBox.Location.X, paintBox.Location.Y, paintBox.Width, paintBox.Height);
                listOfCircles.Add(circle);
        }
    }
}
