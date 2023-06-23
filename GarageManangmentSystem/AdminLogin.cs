using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageManangmentSystem
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void BackLbl_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void GirisYapBtn_Click(object sender, EventArgs e)
        {
            if (AdmPasswordTb.Text=="")
            {
                MessageBox.Show("Şifreyi Giriniz");
            }
            else if (AdmPasswordTb.Text=="admin123")
            {
                Employees Obj = new Employees();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış Admin Şifresi !");
            }
        }
    }
}
