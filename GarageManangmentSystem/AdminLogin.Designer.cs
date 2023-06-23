namespace GarageManangmentSystem
{
    partial class AdminLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BackLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AdmPasswordTb = new System.Windows.Forms.TextBox();
            this.GirisYapBtn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 353);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.BackLbl);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.AdmPasswordTb);
            this.panel2.Controls.Add(this.GirisYapBtn);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(559, 325);
            this.panel2.TabIndex = 0;
            // 
            // BackLbl
            // 
            this.BackLbl.AutoSize = true;
            this.BackLbl.Font = new System.Drawing.Font("Lucida Bright", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.BackLbl.Location = new System.Drawing.Point(242, 266);
            this.BackLbl.Name = "BackLbl";
            this.BackLbl.Size = new System.Drawing.Size(101, 23);
            this.BackLbl.TabIndex = 21;
            this.BackLbl.Text = "Geri Dön";
            this.BackLbl.Click += new System.EventHandler(this.BackLbl_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(65, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 23);
            this.label3.TabIndex = 20;
            this.label3.Text = "Password";
            // 
            // AdmPasswordTb
            // 
            this.AdmPasswordTb.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdmPasswordTb.Location = new System.Drawing.Point(193, 136);
            this.AdmPasswordTb.Name = "AdmPasswordTb";
            this.AdmPasswordTb.Size = new System.Drawing.Size(200, 31);
            this.AdmPasswordTb.TabIndex = 19;
            // 
            // GirisYapBtn
            // 
            this.GirisYapBtn.ActiveBorderThickness = 1;
            this.GirisYapBtn.ActiveCornerRadius = 20;
            this.GirisYapBtn.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.GirisYapBtn.ActiveForecolor = System.Drawing.Color.White;
            this.GirisYapBtn.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.GirisYapBtn.BackColor = System.Drawing.Color.White;
            this.GirisYapBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GirisYapBtn.BackgroundImage")));
            this.GirisYapBtn.ButtonText = "Giriş Yap";
            this.GirisYapBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GirisYapBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GirisYapBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.GirisYapBtn.IdleBorderThickness = 1;
            this.GirisYapBtn.IdleCornerRadius = 20;
            this.GirisYapBtn.IdleFillColor = System.Drawing.Color.DarkSlateGray;
            this.GirisYapBtn.IdleForecolor = System.Drawing.Color.White;
            this.GirisYapBtn.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.GirisYapBtn.Location = new System.Drawing.Point(204, 191);
            this.GirisYapBtn.Margin = new System.Windows.Forms.Padding(5);
            this.GirisYapBtn.Name = "GirisYapBtn";
            this.GirisYapBtn.Size = new System.Drawing.Size(168, 55);
            this.GirisYapBtn.TabIndex = 18;
            this.GirisYapBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GirisYapBtn.Click += new System.EventHandler(this.GirisYapBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(175, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 34);
            this.label2.TabIndex = 22;
            this.label2.Text = "Araç Servisi";
            // 
            // AdminLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminLogin";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label BackLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox AdmPasswordTb;
        private Bunifu.Framework.UI.BunifuThinButton2 GirisYapBtn;
        private System.Windows.Forms.Label label2;
    }
}