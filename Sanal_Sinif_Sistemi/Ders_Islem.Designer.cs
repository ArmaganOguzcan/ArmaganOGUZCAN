namespace Sanal_Sinif_Sistemi
{
    partial class Ders_Islem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ders_Islem));
            this.grp_Islem = new System.Windows.Forms.GroupBox();
            this.chk_Aktiflik_Durumu = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Kaydet = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Duzelt = new System.Windows.Forms.Button();
            this.txt_Aciklama = new System.Windows.Forms.TextBox();
            this.btn_Sil = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Ders_Adi = new System.Windows.Forms.TextBox();
            this.grp_Islem.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_Islem
            // 
            this.grp_Islem.BackColor = System.Drawing.Color.Transparent;
            this.grp_Islem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grp_Islem.Controls.Add(this.chk_Aktiflik_Durumu);
            this.grp_Islem.Controls.Add(this.label3);
            this.grp_Islem.Controls.Add(this.btn_Kaydet);
            this.grp_Islem.Controls.Add(this.label1);
            this.grp_Islem.Controls.Add(this.btn_Duzelt);
            this.grp_Islem.Controls.Add(this.txt_Aciklama);
            this.grp_Islem.Controls.Add(this.btn_Sil);
            this.grp_Islem.Controls.Add(this.label2);
            this.grp_Islem.Controls.Add(this.txt_Ders_Adi);
            this.grp_Islem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.grp_Islem.ForeColor = System.Drawing.Color.MidnightBlue;
            this.grp_Islem.Location = new System.Drawing.Point(20, 20);
            this.grp_Islem.Name = "grp_Islem";
            this.grp_Islem.Size = new System.Drawing.Size(330, 233);
            this.grp_Islem.TabIndex = 6;
            this.grp_Islem.TabStop = false;
            this.grp_Islem.Text = "Ders İşlemleri";
            // 
            // chk_Aktiflik_Durumu
            // 
            this.chk_Aktiflik_Durumu.AutoSize = true;
            this.chk_Aktiflik_Durumu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chk_Aktiflik_Durumu.ForeColor = System.Drawing.Color.White;
            this.chk_Aktiflik_Durumu.Location = new System.Drawing.Point(129, 51);
            this.chk_Aktiflik_Durumu.Name = "chk_Aktiflik_Durumu";
            this.chk_Aktiflik_Durumu.Size = new System.Drawing.Size(114, 20);
            this.chk_Aktiflik_Durumu.TabIndex = 159;
            this.chk_Aktiflik_Durumu.Text = "Aktiflik Durumu";
            this.chk_Aktiflik_Durumu.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Tomato;
            this.label3.Location = new System.Drawing.Point(310, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "*";
            // 
            // btn_Kaydet
            // 
            this.btn_Kaydet.BackColor = System.Drawing.Color.Lavender;
            this.btn_Kaydet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Kaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Kaydet.ForeColor = System.Drawing.Color.DarkBlue;
            this.btn_Kaydet.ImageKey = "add.png";
            this.btn_Kaydet.ImageList = this.ımageList1;
            this.btn_Kaydet.Location = new System.Drawing.Point(57, 183);
            this.btn_Kaydet.Name = "btn_Kaydet";
            this.btn_Kaydet.Size = new System.Drawing.Size(80, 25);
            this.btn_Kaydet.TabIndex = 3;
            this.btn_Kaydet.Text = "Kaydet";
            this.btn_Kaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Kaydet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Kaydet.UseVisualStyleBackColor = false;
            this.btn_Kaydet.Click += new System.EventHandler(this.btn_Kaydet_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "Add.png");
            this.ımageList1.Images.SetKeyName(1, "Delete.png");
            this.ımageList1.Images.SetKeyName(2, "navigate_check.png");
            this.ımageList1.Images.SetKeyName(3, "funnel.png");
            this.ımageList1.Images.SetKeyName(4, "view.png");
            this.ımageList1.Images.SetKeyName(5, "backup_2.png");
            this.ımageList1.Images.SetKeyName(6, "backup2.png");
            this.ımageList1.Images.SetKeyName(7, "backup_1.png");
            this.ımageList1.Images.SetKeyName(8, "Banka_Havale.ico");
            this.ımageList1.Images.SetKeyName(9, "Banka_Islem.ico");
            this.ımageList1.Images.SetKeyName(10, "Banka_Listesi.ico");
            this.ımageList1.Images.SetKeyName(11, "businessmen.png");
            this.ımageList1.Images.SetKeyName(12, "calculator.png");
            this.ımageList1.Images.SetKeyName(13, "exit.png");
            this.ımageList1.Images.SetKeyName(14, "Fatura32x32.png");
            this.ımageList1.Images.SetKeyName(15, "id_card.png");
            this.ımageList1.Images.SetKeyName(16, "Kasa_Listesi.ico");
            this.ımageList1.Images.SetKeyName(17, "Stok_Acilis_Karti_Icon.ico");
            this.ımageList1.Images.SetKeyName(18, "Stok_Grup.ico");
            this.ımageList1.Images.SetKeyName(19, "print.png");
            this.ımageList1.Images.SetKeyName(20, "delete2.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(56, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "Açıklama:";
            // 
            // btn_Duzelt
            // 
            this.btn_Duzelt.BackColor = System.Drawing.Color.Lavender;
            this.btn_Duzelt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Duzelt.ForeColor = System.Drawing.Color.DarkBlue;
            this.btn_Duzelt.ImageKey = "navigate_check.png";
            this.btn_Duzelt.ImageList = this.ımageList1;
            this.btn_Duzelt.Location = new System.Drawing.Point(143, 183);
            this.btn_Duzelt.Name = "btn_Duzelt";
            this.btn_Duzelt.Size = new System.Drawing.Size(80, 25);
            this.btn_Duzelt.TabIndex = 4;
            this.btn_Duzelt.Text = "Düzelt";
            this.btn_Duzelt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Duzelt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Duzelt.UseVisualStyleBackColor = false;
            this.btn_Duzelt.Click += new System.EventHandler(this.btn_Duzelt_Click);
            // 
            // txt_Aciklama
            // 
            this.txt_Aciklama.BackColor = System.Drawing.Color.Lavender;
            this.txt_Aciklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_Aciklama.ForeColor = System.Drawing.Color.DarkBlue;
            this.txt_Aciklama.Location = new System.Drawing.Point(129, 77);
            this.txt_Aciklama.Multiline = true;
            this.txt_Aciklama.Name = "txt_Aciklama";
            this.txt_Aciklama.Size = new System.Drawing.Size(180, 100);
            this.txt_Aciklama.TabIndex = 2;
            this.txt_Aciklama.TextChanged += new System.EventHandler(this.txt_Aciklama_TextChanged);
            // 
            // btn_Sil
            // 
            this.btn_Sil.BackColor = System.Drawing.Color.Lavender;
            this.btn_Sil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Sil.ForeColor = System.Drawing.Color.DarkBlue;
            this.btn_Sil.ImageKey = "delete.png";
            this.btn_Sil.ImageList = this.ımageList1;
            this.btn_Sil.Location = new System.Drawing.Point(229, 183);
            this.btn_Sil.Name = "btn_Sil";
            this.btn_Sil.Size = new System.Drawing.Size(80, 25);
            this.btn_Sil.TabIndex = 5;
            this.btn_Sil.Text = "Sil";
            this.btn_Sil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Sil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Sil.UseVisualStyleBackColor = false;
            this.btn_Sil.Click += new System.EventHandler(this.btn_Sil_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(59, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "Ders Adı:";
            // 
            // txt_Ders_Adi
            // 
            this.txt_Ders_Adi.BackColor = System.Drawing.Color.Lavender;
            this.txt_Ders_Adi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_Ders_Adi.ForeColor = System.Drawing.Color.DarkBlue;
            this.txt_Ders_Adi.Location = new System.Drawing.Point(129, 23);
            this.txt_Ders_Adi.Name = "txt_Ders_Adi";
            this.txt_Ders_Adi.Size = new System.Drawing.Size(180, 22);
            this.txt_Ders_Adi.TabIndex = 0;
            this.txt_Ders_Adi.TextChanged += new System.EventHandler(this.txt_Ders_Adi_TextChanged);
            // 
            // Ders_Islem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(374, 271);
            this.Controls.Add(this.grp_Islem);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Ders_Islem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ders İşlem::..";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ders_Islemler_FormClosing);
            this.Load += new System.EventHandler(this.Ders_Islemler_Load);
            this.grp_Islem.ResumeLayout(false);
            this.grp_Islem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_Islem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Kaydet;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Duzelt;
        private System.Windows.Forms.TextBox txt_Aciklama;
        private System.Windows.Forms.Button btn_Sil;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Ders_Adi;
        private System.Windows.Forms.CheckBox chk_Aktiflik_Durumu;
    }
}