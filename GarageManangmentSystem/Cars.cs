using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GarageManangmentSystem
{
    public partial class Cars : Form
    {
        public Cars()
        {
            InitializeComponent();
            displayCars();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-E24EG0EI;Initial Catalog=GarageDb;Integrated Security=True");
        private void displayCars()
        {
            Con.Open();
            String Query = "select * from AracTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AracDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void EkleBtn_Click(object sender, EventArgs e)
        {
            if (AracNumaraTb.Text == "Araç Numarası" || AracMarkaTb.Text == "Araç Markası" || AracModelTb.Text == "Araç Modeli" || AracRenkTb.Text == "Araç Rengi" || AracSahipAdiTb.Text == "Araç Sahip Adı"|| AracNumaraTb.Text ==""|| AracMarkaTb.Text ==""|| AracModelTb.Text ==""|| AracRenkTb.Text ==""|| AracSahipAdiTb.Text =="") 
            {
                MessageBox.Show("Hatalı Giriş");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into AracTbl(AracNumara, AracMarka, AracModel, AracTarih, AracRenk, AracSahipAdi) values (@AN, @AMR, @AMO, @AT, @AR, @ASA)", Con);
                    cmd.Parameters.AddWithValue("@AN", AracNumaraTb.Text);
                    cmd.Parameters.AddWithValue("@AMR", AracMarkaTb.Text);
                    cmd.Parameters.AddWithValue("@AMO", AracModelTb.Text);

                    DateTime aracTarih;
                    if (DateTime.TryParse(AracTarih.Text, out aracTarih))
                    {
                        cmd.Parameters.AddWithValue("@AT", aracTarih);
                    }
                    else
                    {
                       
                    }

                    cmd.Parameters.AddWithValue("@AR", AracRenkTb.Text);
                    cmd.Parameters.AddWithValue("@ASA", AracSahipAdiTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Araç Kayıt");
                    Con.Close();
                    displayCars();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int key = 0;
        string AracKey = "";
        private void AracDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AracNumaraTb.Text = AracDGV.SelectedRows[0].Cells[0].Value.ToString();
            AracKey = AracDGV.SelectedRows[0].Cells[0].Value.ToString();
            AracMarkaTb.Text = AracDGV.SelectedRows[0].Cells[1].Value.ToString();
            AracModelTb.Text = AracDGV.SelectedRows[0].Cells[2].Value.ToString();
            AracTarih.Text = AracDGV.SelectedRows[0].Cells[3].Value.ToString();
            AracRenkTb.Text = AracDGV.SelectedRows[0].Cells[4].Value.ToString();
            AracSahipAdiTb.Text = AracDGV.SelectedRows[0].Cells[5].Value.ToString();
            
        }

        private void SilBtn_Click(object sender, EventArgs e)
        {
            if (AracKey=="")
            {
                MessageBox.Show("Araç Seçiniz");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from AracTbl where AracNumara=@AN", Con);
                    cmd.Parameters.AddWithValue("@AN", AracKey);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Araç Silindi");
                    Con.Close();
                    displayCars();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DüzenleBtn_Click(object sender, EventArgs e)
        {
            if (AracNumaraTb.Text == "Araç Numarası" || AracMarkaTb.Text == "Araç Markası" || AracModelTb.Text == "Araç Modeli" || AracRenkTb.Text == "Araç Rengi" || AracSahipAdiTb.Text == "Araç Sahip Adı" || AracNumaraTb.Text == "" || AracMarkaTb.Text == "" || AracModelTb.Text == "" || AracRenkTb.Text == "" || AracSahipAdiTb.Text == "")
            {
                MessageBox.Show("Hatalı Giriş");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update AracTbl set AracMarka = @AMR, AracModel = @AMO, AracTarih = @AT, AracRenk = @AR, AracSahipAdi = @ASA where AracNumara = @AN", Con);
                    cmd.Parameters.AddWithValue("@AN", AracNumaraTb.Text);
                    cmd.Parameters.AddWithValue("@AMR", AracMarkaTb.Text);
                    cmd.Parameters.AddWithValue("@AMO", AracModelTb.Text);

                    DateTime aracTarih;
                    if (DateTime.TryParse(AracTarih.Text, out aracTarih))
                    {
                        cmd.Parameters.AddWithValue("@AT", aracTarih);
                    }
                    else
                    {
                       
                    }

                    cmd.Parameters.AddWithValue("@AR", AracRenkTb.Text);
                    cmd.Parameters.AddWithValue("@ASA", AracSahipAdiTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Araç Güncellendi");
                    Con.Close();
                    displayCars();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
