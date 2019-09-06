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
        }


        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Graphics graph = this.CreateGraphics();
            foreach (var myPoint in points)
            {
                Pen pen = new Pen(myPoint.Color, myPoint.Width);             
                Pen pen2 = new Pen(Box.BackColor, myPoint.Width);
                graph.DrawEllipse(pen2, myPoint.x, myPoint.y, myPoint.Width, myPoint.Width);

                myPoint.Way(Box.Width, Box.Height, Box.Location.X, Box.Location.Y);
                graph.DrawEllipse(pen, myPoint.x, myPoint.y, myPoint.Width, myPoint.Width);
                myPoint.TimeLife++;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {     
            timer1.Enabled = !timer1.Enabled;
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
            string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zheka\Desktop\Points\Points\Database2.mdf;Integrated Security=True";
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
