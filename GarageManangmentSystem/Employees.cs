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
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            displayEmployee();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-E24EG0EI;Initial Catalog=GarageDb;Integrated Security=True");
        private void displayEmployee()
        {
            Con.Open();
            String Query = "select * from CalisanTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CalisanDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void EkleBtn_Click(object sender, EventArgs e)
        {
            if (CalisanAdTb.Text == "Çalışan Adı" || CalisanAdresTb.Text == "Çalışan Adresi" || CalisanParolaTb.Text == "Çalışan Parolası" || CalisanCinsiyetCb.SelectedIndex == -1 || CalisanAdTb.Text == "" || CalisanAdresTb.Text == "")
            {
                MessageBox.Show("Hatalı Giriş");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into CalisanTbl(CalisanAdi,CalisanCinsiyet,CalisanAdres,CalisanParola) values(@CA,@CC,@CADR,@CP)", Con);
                    cmd.Parameters.AddWithValue("@CA", CalisanAdTb.Text);
                    cmd.Parameters.AddWithValue("@CC", CalisanCinsiyetCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CADR", CalisanAdresTb.Text);
                    cmd.Parameters.AddWithValue("@CP", CalisanParolaTb.Text);
                   
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Çalışan Kayıt edildi");
                    Con.Close();
                    displayEmployee();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int Key = 0;
        string CalisanKey;
        private void CalisanDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CalisanAdTb.Text = CalisanDGV.SelectedRows[0].Cells[1].Value.ToString();
            CalisanCinsiyetCb.SelectedItem = CalisanDGV.SelectedRows[0].Cells[2].Value.ToString();
            CalisanAdresTb.Text = CalisanDGV.SelectedRows[0].Cells[3].Value.ToString();
            CalisanParolaTb.Text = CalisanDGV.SelectedRows[0].Cells[4].Value.ToString();
            
            if (CalisanAdTb.Text=="")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CalisanDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void SilBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Araç Seçiniz");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from CalisanTbl where CalisanId=@EId", Con);
                    cmd.Parameters.AddWithValue("@EId", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Çalışan Silindi");
                    Con.Close();
                    displayEmployee();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DüzenleBtn_Click(object sender, EventArgs e)
        {
            if (CalisanAdTb.Text == "Çalışan Adı" || CalisanAdresTb.Text == "Çalışan Adresi" || CalisanParolaTb.Text == "Çalışan Parolası" || CalisanCinsiyetCb.SelectedIndex == -1 || CalisanAdTb.Text == "" || CalisanAdresTb.Text == "")
            {
                MessageBox.Show("Hatalı Giriş");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update CalisanTbl set CalisanAdi=@CA,CalisanCinsiyet=@CC,CalisanAdres=@CADR,CalisanParola=@CP where CalisanId=@EId",Con);
                    cmd.Parameters.AddWithValue("@EId", Key);
                    cmd.Parameters.AddWithValue("@CA", CalisanAdTb.Text);
                    cmd.Parameters.AddWithValue("@CC", CalisanCinsiyetCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CADR", CalisanAdresTb.Text);
                    cmd.Parameters.AddWithValue("@CP", CalisanParolaTb.Text);           
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Çalışan Güncellendi");
                    Con.Close();
                    displayEmployee();
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

        private void StokLbl2_Click(object sender, EventArgs e)
        {
            Stocks Obj = new Stocks();
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
