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
    public partial class Stocks : Form
    {
        public Stocks()
        {
            InitializeComponent();
            displayStock();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-E24EG0EI;Initial Catalog=GarageDb;Integrated Security=True");
        private void displayStock()
        {
            Con.Open();
            String Query = "select * from StokTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ParcaDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void EkleBtn_Click(object sender, EventArgs e)
        {
            if (ParcaAdiTb.Text == "Parça Adı" || ParcaMiktarTb.Text == "Parça Miktarı" || ParcaFiyatTb.Text == "Parça Fiyatı" || ParcaAdiTb.Text == "" || ParcaMiktarTb.Text == "" || ParcaFiyatTb.Text == "")
            {
                MessageBox.Show("Hatalı Giriş");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into StokTbl(ParcaAd,ParcaMiktar,ParcaFiyat) values(@PA,@PM,@PF)", Con);
                    cmd.Parameters.AddWithValue("@PA", ParcaAdiTb.Text);
                    cmd.Parameters.AddWithValue("@PM", ParcaMiktarTb.Text);
                    cmd.Parameters.AddWithValue("@PF", ParcaFiyatTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Parça Kayıt Edildi");
                    Con.Close();
                    displayStock();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int Key = 0;
        private void ParcaDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ParcaAdiTb.Text = ParcaDGV.SelectedRows[0].Cells[1].Value.ToString();
            ParcaMiktarTb.Text = ParcaDGV.SelectedRows[0].Cells[2].Value.ToString();
            ParcaFiyatTb.Text = ParcaDGV.SelectedRows[0].Cells[3].Value.ToString();

            if (ParcaAdiTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ParcaDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void SilBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Parça Seçiniz");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from StokTbl where ParcaId=@PId", Con);
                    cmd.Parameters.AddWithValue("@PId", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Parça Silindi");
                    Con.Close();
                    displayStock();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DüzenleBtn_Click(object sender, EventArgs e)
        {
            if (ParcaAdiTb.Text == "Parça Adı" || ParcaMiktarTb.Text == "Parça Miktarı" || ParcaFiyatTb.Text == "Çalışan Parolası" || ParcaAdiTb.Text == "" || ParcaMiktarTb.Text == "" || ParcaFiyatTb.Text == "")
            {
                MessageBox.Show("Hatalı Giriş");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update StokTbl set ParcaAd=@PA,ParcaMiktar=@PM,ParcaFiyat=@PF where ParcaId=@PId", Con);
                    cmd.Parameters.AddWithValue("@PId", Key);
                    cmd.Parameters.AddWithValue("@PA", ParcaAdiTb.Text);
                    cmd.Parameters.AddWithValue("@PM", ParcaMiktarTb.Text);
                    cmd.Parameters.AddWithValue("@PF", ParcaFiyatTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Çalışan Güncellendi");
                    Con.Close();
                    displayStock();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ArclrLbL1_Click(object sender, EventArgs e)
        {
            Cars Obj = new Cars();
            Obj.Show();
            this.Hide();
        }

        private void ClisalrLbl3_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void AnalizLbl5_Click(object sender, EventArgs e)
        {
            DashBoard Obj = new DashBoard();
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
