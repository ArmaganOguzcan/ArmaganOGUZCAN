namespace Sanal_Sinif_Sistemi
{
    partial class Kullanici_Giris
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kullanici_Giris));
            this.grp_Kullanici_Giris = new System.Windows.Forms.GroupBox();
            this.txt_Kul_Sifre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Kul_Adi = new System.Windows.Forms.TextBox();
            this.btn_Giris = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grp_Kullanici_Giris.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_Kullanici_Giris
            // 
            this.grp_Kullanici_Giris.BackColor = System.Drawing.Color.Transparent;
            this.grp_Kullanici_Giris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grp_Kullanici_Giris.Controls.Add(this.txt_Kul_Sifre);
            this.grp_Kullanici_Giris.Controls.Add(this.label6);
            this.grp_Kullanici_Giris.Controls.Add(this.label2);
            this.grp_Kullanici_Giris.Controls.Add(this.txt_Kul_Adi);
            this.grp_Kullanici_Giris.Controls.Add(this.btn_Giris);
            this.grp_Kullanici_Giris.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.grp_Kullanici_Giris.ForeColor = System.Drawing.Color.MidnightBlue;
            this.grp_Kullanici_Giris.Location = new System.Drawing.Point(58, 134);
            this.grp_Kullanici_Giris.Name = "grp_Kullanici_Giris";
            this.grp_Kullanici_Giris.Size = new System.Drawing.Size(288, 134);
            this.grp_Kullanici_Giris.TabIndex = 10;
            this.grp_Kullanici_Giris.TabStop = false;
            this.grp_Kullanici_Giris.Text = "Kullanıcı Giriş";
            // 
            // txt_Kul_Sifre
            // 
            this.txt_Kul_Sifre.BackColor = System.Drawing.Color.Lavender;
            this.txt_Kul_Sifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_Kul_Sifre.ForeColor = System.Drawing.Color.DarkBlue;
            this.txt_Kul_Sifre.Location = new System.Drawing.Point(123, 58);
            this.txt_Kul_Sifre.Name = "txt_Kul_Sifre";
            this.txt_Kul_Sifre.PasswordChar = '*';
            this.txt_Kul_Sifre.Size = new System.Drawing.Size(147, 22);
            this.txt_Kul_Sifre.TabIndex = 1;
            this.txt_Kul_Sifre.Text = "D123";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.AliceBlue;
            this.label6.Location = new System.Drawing.Point(13, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 16);
            this.label6.TabIndex = 32;
            this.label6.Text = "Kullanıcı Şifre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.AliceBlue;
            this.label2.Location = new System.Drawing.Point(20, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "Kullanıcı Adı:";
            // 
            // txt_Kul_Adi
            // 
            this.txt_Kul_Adi.BackColor = System.Drawing.Color.Lavender;
            this.txt_Kul_Adi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_Kul_Adi.ForeColor = System.Drawing.Color.DarkBlue;
            this.txt_Kul_Adi.Location = new System.Drawing.Point(123, 30);
            this.txt_Kul_Adi.Name = "txt_Kul_Adi";
            this.txt_Kul_Adi.Size = new System.Drawing.Size(147, 22);
            this.txt_Kul_Adi.TabIndex = 0;
            this.txt_Kul_Adi.Text = "Sevket321";
            // 
            // btn_Giris
            // 
            this.btn_Giris.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Giris.ImageKey = "personel.ico";
            this.btn_Giris.ImageList = this.ımageList1;
            this.btn_Giris.Location = new System.Drawing.Point(205, 86);
            this.btn_Giris.Name = "btn_Giris";
            this.btn_Giris.Size = new System.Drawing.Size(65, 30);
            this.btn_Giris.TabIndex = 2;
            this.btn_Giris.Text = "Giriş";
            this.btn_Giris.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Giris.UseVisualStyleBackColor = true;
            this.btn_Giris.Click += new System.EventHandler(this.btn_Giris_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "Add.png");
            this.ımageList1.Images.SetKeyName(1, "arrow_right_blue.png");
            this.ımageList1.Images.SetKeyName(2, "arrow_right_green.png");
            this.ımageList1.Images.SetKeyName(3, "backup_1.png");
            this.ımageList1.Images.SetKeyName(4, "backup_2.png");
            this.ımageList1.Images.SetKeyName(5, "Banka_Listesi.ico");
            this.ımageList1.Images.SetKeyName(6, "businessmen.png");
            this.ımageList1.Images.SetKeyName(7, "calculator.png");
            this.ımageList1.Images.SetKeyName(8, "Delete.png");
            this.ımageList1.Images.SetKeyName(9, "delete2.png");
            this.ımageList1.Images.SetKeyName(10, "exit.png");
            this.ımageList1.Images.SetKeyName(11, "export1.png");
            this.ımageList1.Images.SetKeyName(12, "export2.png");
            this.ımageList1.Images.SetKeyName(13, "Fatura32x32.png");
            this.ımageList1.Images.SetKeyName(14, "funnel.png");
            this.ımageList1.Images.SetKeyName(15, "id_card.png");
            this.ımageList1.Images.SetKeyName(16, "Kasa_Listesi.ico");
            this.ımageList1.Images.SetKeyName(17, "login.ico");
            this.ımageList1.Images.SetKeyName(18, "navigate_check.png");
            this.ımageList1.Images.SetKeyName(19, "ogrenci.ico");
            this.ımageList1.Images.SetKeyName(20, "personel.ico");
            this.ımageList1.Images.SetKeyName(21, "print.png");
            this.ımageList1.Images.SetKeyName(22, "Right.ico");
            this.ımageList1.Images.SetKeyName(23, "sinav.ico");
            this.ımageList1.Images.SetKeyName(24, "view.png");
            // 
            // Kullanici_Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(393, 365);
            this.Controls.Add(this.grp_Kullanici_Giris);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Kullanici_Giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Giriş::..";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Kullanici_Giris_FormClosed);
            this.Load += new System.EventHandler(this.Kullanici_Giris_Load);
            this.grp_Kullanici_Giris.ResumeLayout(false);
            this.grp_Kullanici_Giris.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_Kullanici_Giris;
        private System.Windows.Forms.TextBox txt_Kul_Sifre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Kul_Adi;
        private System.Windows.Forms.Button btn_Giris;
        private System.Windows.Forms.ImageList ımageList1;
    }
}