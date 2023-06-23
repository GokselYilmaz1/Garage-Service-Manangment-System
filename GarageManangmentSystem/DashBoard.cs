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

namespace GarageManangmentSystem
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            CountAraclar();
            CountCalisanlar();
            CountYedekParca();
            SumTutar();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-E24EG0EI;Initial Catalog=GarageDb;Integrated Security=True");
        private void CountAraclar()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from AracTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            AracLbl.Text = dt.Rows[0][0].ToString();
        }
        private void CountCalisanlar()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from CalisanTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CalisanlarLbl.Text = dt.Rows[0][0].ToString();
        }
        private void CountYedekParca()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from StokTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ydkprcaLbl.Text = dt.Rows[0][0].ToString();
        }
        private void SumTutar()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select Sum(ToplamUcret) from FaturaTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            TutarLbl.Text = dt.Rows[0][0].ToString();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Cars Obj = new Cars();
            Obj.Show();
            this.Hide();
        }

        private void StokLbl2_Click(object sender, EventArgs e)
        {
            Stocks Obj = new Stocks();
            Obj.Show();
            this.Hide();
        }

        private void ClisalrLbl3_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
