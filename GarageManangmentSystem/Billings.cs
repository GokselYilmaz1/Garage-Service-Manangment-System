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
    public partial class Billings : Form
    {
        public Billings()
        {
            InitializeComponent();
            displayStock();
            GetCars();
            CalisanAdiLbl.Text = Login.Username;
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-E24EG0EI;Initial Catalog=GarageDb;Integrated Security=True");
        private void GetCars()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select AracNumara from AracTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("AracNumara", typeof(string));
            dt.Load(rdr);
            AracNumaraCb.ValueMember = "AracNumara";
            AracNumaraCb.DataSource = dt;
            Con.Close();
        }
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

        //int miktar = 0, fiyat = 0, Key = 0;
        //string ParcaAdi = "";
        private void ParcaDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ParcaAdi = ParcaDGV.SelectedRows[0].Cells[1].Value.ToString();
            miktar = Convert.ToInt32(ParcaDGV.SelectedRows[0].Cells[2].Value.ToString());
            fiyat =Convert.ToInt32(ParcaDGV.SelectedRows[0].Cells[3].Value.ToString());

            if (ParcaAdi == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ParcaDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        //int n = 0, numara;
         
        private void MiktarGuncelle()
        {
            int newMiktar = miktar - Convert.ToInt32(miktarTb.Text);
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("update StokTbl set ParcaMiktar=@PM where ParcaId=@PId", Con);
                cmd.Parameters.AddWithValue("@PId", Key);

                cmd.Parameters.AddWithValue("@PM", newMiktar);
                
                cmd.ExecuteNonQuery();
                
                Con.Close();
                displayStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int n = 0, numara;
        int toplam = 0, GridToplam = 0;
        private void ParcaEkleBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0 || miktarTb.Text == "Miktar" || miktarTb.Text == "")
            {
                MessageBox.Show("Eklenecek Yedek Parçayı Seçin");
            }
            else if (Convert.ToInt32(miktarTb.Text) > miktar)
            {
                MessageBox.Show("Yeterli Stok Yok");
            }
            else {
                numara = Convert.ToInt32(miktarTb.Text);
                DataGridViewRow newRow = new DataGridViewRow(); // row = dizi
                newRow.CreateCells(Parca2DGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = ParcaAdi;
                toplam = numara * fiyat;
                newRow.Cells[2].Value = numara;
                newRow.Cells[3].Value = fiyat;
                
                newRow.Cells[4].Value = toplam;
                Parca2DGV.Rows.Add(newRow);
                n++;
                
                GridToplam = GridToplam + toplam;
                ParcaUcretLbl.Text = "Rs" + GridToplam;
                MiktarGuncelle();
                miktarTb.Text = "";
            }
        }

        int TplmUcrt = 0;
        private void HesaplayıcıBtn_Click(object sender, EventArgs e)
        {
            if (MekUcrTb.Text == "Mekanik Ücretler" || MekUcrTb.Text == "")
            {
                MessageBox.Show("Geçerli bir miktar girin");
            }
            else if (ParcaUcretLbl.Text == "Parça Ücreti")
            {
                TplmUcrt = Convert.ToInt32(MekUcrTb.Text);
                ToplamUcretLbl.Text = "Rs" + Convert.ToString(MekUcrTb.Text);
            }
            else
            {
                TplmUcrt = Convert.ToInt32(MekUcrTb.Text);
                ToplamUcretLbl.Text = "Rs" + Convert.ToString(GridToplam + Convert.ToInt32(MekUcrTb.Text));

            }
        }
        int miktar = 0, fiyat = 0, Key = 0;

        private void label10_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        string ParcaAdi = "";
        private void FtraKydBtn_Click(object sender, EventArgs e)
        {
            if (AracNumaraCb.SelectedIndex == -1 || ToplamUcretLbl.Text == "Toplam Ücret")
            {
                MessageBox.Show("Eksik Veri Algılandı");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into FaturaTbl(AracNumarasi,FaturaTarihi,MekanikUcretler,ParcaUcretleri,ToplamUcret,CalisanAdi) values(@AN,@FT,@MU,@PU,@TU,@Cİ)", Con);
                    cmd.Parameters.AddWithValue("@AN", AracNumaraCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@FT", FtrTrh.Value.Date);
                    cmd.Parameters.AddWithValue("@MU", MekUcrTb.Text);
                    cmd.Parameters.AddWithValue("@PU", GridToplam);
                    cmd.Parameters.AddWithValue("@TU", TplmUcrt);
                    cmd.Parameters.AddWithValue("@Cİ", CalisanAdiLbl.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fatura Kayıt edildi");
                    Con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
