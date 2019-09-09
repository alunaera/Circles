using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace Points
{

    public partial class MainForm : Form
    {
        List<Point> points = new List<Point>();
        Random rnd = new Random();
        SqlConnection SqlConnection;
        public MainForm()
        {
            InitializeComponent();
            this.Paint += OnPaint;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            foreach (var myPoint in points)
            {
                Pen pen = new Pen(myPoint.Color, myPoint.Width);
                Pen pen2 = new Pen(Box.BackColor, myPoint.Width);
                e.Graphics.DrawEllipse(pen2, myPoint.x, myPoint.y, myPoint.Width, myPoint.Width);
                e.Graphics.DrawEllipse(pen, myPoint.x, myPoint.y, myPoint.Width, myPoint.Width);
            }
        }
         
        private void Timer1_Tick(object sender, EventArgs e)
        {
            foreach (var myPoint in points)
            {
                myPoint.UpdateWay(Box.Width, Box.Height, Box.Location.X, Box.Location.Y);
                myPoint.TimeLife++;
            }

            label1.Text = "Шаров: " + points.Count;
            Refresh();
        }

        private void Button1_Click(object sender, EventArgs e)
        {     
            timer1.Enabled = !timer1.Enabled;
            if (Start.Text == "Старт")
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
            Point element = new Point(rnd.Next(0, 300), rnd.Next(0, 300));
            points.Add(element);

            CommandSQL command = new CommandSQL();
            command.SelectId(SqlConnection, element.Id);
            command.InsertPoint(SqlConnection, element.Color.ToString(), element.Width, element.Weight);           
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="
                + baseDirectory.Substring(0, baseDirectory.Length - 10)
                + "Database2.mdf;Integrated Security=True";
            SqlConnection = new SqlConnection(connection_string);
            await SqlConnection.OpenAsync();
        }
        private void ДобавитьСтатистикуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommandSQL command = new CommandSQL();
            foreach (var item in points)
            {
                command.AddStats(SqlConnection, item.Id, item.BumpCount, item.TimeLife);
            }
        }
    }
}
