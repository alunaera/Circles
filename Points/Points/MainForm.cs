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
                Pen pen = new Pen(Color.FromName(myPoint.Color), myPoint.Width);             
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

        private async void AddPoint_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Point el = new Point(rnd.Next(0, 300), rnd.Next(0, 300));
            points.Add(el);

            SqlCommand commandId = new SqlCommand("SELECT MAX(Id) + 1 FROM [Points]", SqlConnection);
            object result = commandId.ExecuteScalar();
            el.Id = Convert.ToInt16(result);

            SqlCommand commandInsert = new SqlCommand("INSERT INTO [Points] (Color, Width, Weight)" +
                                                "VALUES (@Color, @Width, @Weight)", SqlConnection);
            commandInsert.Parameters.AddWithValue("Color", el.Color);
            commandInsert.Parameters.AddWithValue("Width", el.Width);
            commandInsert.Parameters.AddWithValue("Weight", el.Weight);
            await commandInsert.ExecuteNonQueryAsync();         
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zheka\Desktop\Points\Points\Database2.mdf;Integrated Security=True";
            SqlConnection = new SqlConnection(connection_string);
            await SqlConnection.OpenAsync();
            
        }

        private async void Button1_Click_1(object sender, EventArgs e)
        {
            foreach (var item in points)
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Stats] (Id, BumpCount, TimeLife)" +
                                                "VALUES (@Id, @BumpCount, @TimeLife)", SqlConnection);

                command.Parameters.AddWithValue("Id", item.Id);
                command.Parameters.AddWithValue("BumpCount", item.BumpCount);
                command.Parameters.AddWithValue("TimeLife", item.TimeLife);
                await command.ExecuteNonQueryAsync();
            }
        }

        private async void ДобавитьСтатистикуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in points)
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Stats] (Id, BumpCount, TimeLife)" +
                                                "VALUES (@Id, @BumpCount, @TimeLife)", SqlConnection);

                command.Parameters.AddWithValue("Id", item.Id);
                command.Parameters.AddWithValue("BumpCount", item.BumpCount);
                command.Parameters.AddWithValue("TimeLife", item.TimeLife);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
