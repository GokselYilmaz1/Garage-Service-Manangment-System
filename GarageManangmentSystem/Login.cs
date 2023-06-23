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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminLogin Obj = new AdminLogin();
            Obj.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-E24EG0EI;Initial Catalog=GarageDb;Integrated Security=True");
        public static string Username = "";
        private void GirisYapBtn_Click(object sender, EventArgs e)
        {
            if (UserNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Kullanıcı Adı Ve Şifrenizi Girin");
            }
            else 
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from CalisanTbl where CalisanAdi='" + UserNameTb.Text + "' and CalisanParola='" + PasswordTb.Text + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString()=="1")
                {
                    Username = UserNameTb.Text;
                    Billings Obj = new Billings();
                    Obj.Show();
                    this.Hide();
                    Con.Close();
                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı Veya Şifre");
                }
                Con.Close();
            }
        }
    }
}
