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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            timer1.Start();
        }

        int baslaT = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            baslaT += 1;
            PrgressBar.Value = baslaT;
            YuzdeLbl.Text = baslaT + "%";
            if (PrgressBar.Value==100)
            {
                PrgressBar.Value = 0;
                timer1.Stop();
                Login Obj = new Login();
                Obj.Show();
                this.Hide();
            }
        }
    }
}
