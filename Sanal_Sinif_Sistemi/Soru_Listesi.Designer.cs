namespace Sanal_Sinif_Sistemi
{
    partial class Soru_Listesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Soru_Listesi));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chk_Ders = new System.Windows.Forms.CheckBox();
            this.btn_Temizle = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Yazdir = new System.Windows.Forms.Button();
            this.cmb_Ders = new System.Windows.Forms.ComboBox();
            this.lbl_Liste_Adet = new System.Windows.Forms.Label();
            this.btn_Sil = new System.Windows.Forms.Button();
            this.btn_Detay = new System.Windows.Forms.Button();
            this.chk_Konu = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_Yeni_Kayit = new System.Windows.Forms.Button();
            this.btn_Filtrele = new System.Windows.Forms.Button();
            this.pnl_Islem = new System.Windows.Forms.Panel();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grd_Liste = new System.Windows.Forms.DataGridView();
            this.grp_Filtre = new System.Windows.Forms.GroupBox();
            this.chk_Aktiflik = new System.Windows.Forms.CheckBox();
            this.chk_Aktiflik_Durumu = new System.Windows.Forms.CheckBox();
            this.chk_Soru = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Soru = new System.Windows.Forms.TextBox();
            this.cmb_Konu = new System.Windows.Forms.ComboBox();
            this.grp_Liste = new System.Windows.Forms.GroupBox();
            this.pnl_Islem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Liste)).BeginInit();
            this.grp_Filtre.SuspendLayout();
            this.grp_Liste.SuspendLayout();
            this.SuspendLayout();
            // 
            // chk_Ders
            // 
            this.chk_Ders.AutoSize = true;
            this.chk_Ders.Location = new System.Drawing.Point(279, 23);
            this.chk_Ders.Name = "chk_Ders";
            this.chk_Ders.Size = new System.Drawing.Size(15, 14);
            this.chk_Ders.TabIndex = 0;
            this.chk_Ders.UseVisualStyleBackColor = true;
            this.chk_Ders.CheckedChanged += new System.EventHandler(this.chk_Ders_CheckedChanged);
            // 
            // btn_Temizle
            // 
            this.btn_Temizle.BackColor = System.Drawing.Color.Lavender;
            this.btn_Temizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Temizle.ForeColor = System.Drawing.Color.DarkBlue;
            this.btn_Temizle.ImageKey = "delete2.png";
            this.btn_Temizle.ImageList = this.ımageList1;
            this.btn_Temizle.Location = new System.Drawing.Point(197, 171);
            this.btn_Temizle.Name = "btn_Temizle";
            this.btn_Temizle.Size = new System.Drawing.Size(76, 34);
            this.btn_Temizle.TabIndex = 9;
            this.btn_Temizle.Text = "Temizle";
            this.btn_Temizle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Temizle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Temizle.UseVisualStyleBackColor = false;
            this.btn_Temizle.Click += new System.EventHandler(this.btn_Temizle_Click);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(70, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "Ders:";
            // 
            // btn_Yazdir
            // 
            this.btn_Yazdir.BackColor = System.Drawing.Color.Lavender;
            this.btn_Yazdir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Yazdir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_Yazdir.ForeColor = System.Drawing.Color.DarkBlue;
            this.btn_Yazdir.ImageKey = "print.png";
            this.btn_Yazdir.ImageList = this.ımageList1;
            this.btn_Yazdir.Location = new System.Drawing.Point(201, 7);
            this.btn_Yazdir.Name = "btn_Yazdir";
            this.btn_Yazdir.Size = new System.Drawing.Size(60, 25);
            this.btn_Yazdir.TabIndex = 13;
            this.btn_Yazdir.Text = "Yazdır";
            this.btn_Yazdir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Yazdir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Yazdir.UseVisualStyleBackColor = false;
            this.btn_Yazdir.Click += new System.EventHandler(this.btn_Yazdir_Click);
            // 
            // cmb_Ders
            // 
            this.cmb_Ders.BackColor = System.Drawing.Color.Lavender;
            this.cmb_Ders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Ders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_Ders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmb_Ders.ForeColor = System.Drawing.Color.DarkBlue;
            this.cmb_Ders.FormattingEnabled = true;
            this.cmb_Ders.Location = new System.Drawing.Point(123, 19);
            this.cmb_Ders.Name = "cmb_Ders";
            this.cmb_Ders.Size = new System.Drawing.Size(150, 24);
            this.cmb_Ders.TabIndex = 1;
            this.cmb_Ders.SelectedIndexChanged += new System.EventHandler(this.cmb_Ders_SelectedIndexChanged);
            // 
            // lbl_Liste_Adet
            // 
            this.lbl_Liste_Adet.AutoSize = true;
            this.lbl_Liste_Adet.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Liste_Adet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lbl_Liste_Adet.ForeColor = System.Drawing.Color.White;
            this.lbl_Liste_Adet.Location = new System.Drawing.Point(3, 35);
            this.lbl_Liste_Adet.Name = "lbl_Liste_Adet";
            this.lbl_Liste_Adet.Size = new System.Drawing.Size(141, 16);
            this.lbl_Liste_Adet.TabIndex = 31;
            this.lbl_Liste_Adet.Text = "0 Adet Kayıt Listelendi.";
            this.lbl_Liste_Adet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Sil
            // 
            this.btn_Sil.BackColor = System.Drawing.Color.Lavender;
            this.btn_Sil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Sil.ForeColor = System.Drawing.Color.DarkBlue;
            this.btn_Sil.ImageKey = "delete.png";
            this.btn_Sil.ImageList = this.ımageList1;
            this.btn_Sil.Location = new System.Drawing.Point(135, 7);
            this.btn_Sil.Name = "btn_Sil";
            this.btn_Sil.Size = new System.Drawing.Size(60, 25);
            this.btn_Sil.TabIndex = 12;
            this.btn_Sil.Text = "Sil";
            this.btn_Sil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Sil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Sil.UseVisualStyleBackColor = false;
            this.btn_Sil.Click += new System.EventHandler(this.btn_Sil_Click);
            // 
            // btn_Detay
            // 
            this.btn_Detay.BackColor = System.Drawing.Color.Lavender;
            this.btn_Detay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_Detay.ForeColor = System.Drawing.Color.DarkBlue;
            this.btn_Detay.ImageKey = "view.png";
            this.btn_Detay.ImageList = this.ımageList1;
            this.btn_Detay.Location = new System.Drawing.Point(69, 7);
            this.btn_Detay.Name = "btn_Detay";
            this.btn_Detay.Size = new System.Drawing.Size(60, 25);
            this.btn_Detay.TabIndex = 11;
            this.btn_Detay.Text = "Detay";
            this.btn_Detay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Detay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Detay.UseVisualStyleBackColor = false;
            this.btn_Detay.Click += new System.EventHandler(this.btn_Detay_Click);
            // 
            // chk_Konu
            // 
            this.chk_Konu.AutoSize = true;
            this.chk_Konu.Location = new System.Drawing.Point(279, 55);
            this.chk_Konu.Name = "chk_Konu";
            this.chk_Konu.Size = new System.Drawing.Size(15, 14);
            this.chk_Konu.TabIndex = 2;
            this.chk_Konu.UseVisualStyleBackColor = true;
            this.chk_Konu.CheckedChanged += new System.EventHandler(this.chk_Konu_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(69, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 16);
            this.label13.TabIndex = 159;
            this.label13.Text = "Konu:";
            // 
            // btn_Yeni_Kayit
            // 
            this.btn_Yeni_Kayit.BackColor = System.Drawing.Color.Lavender;
            this.btn_Yeni_Kayit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Yeni_Kayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_Yeni_Kayit.ForeColor = System.Drawing.Color.DarkBlue;
            this.btn_Yeni_Kayit.ImageKey = "add.png";
            this.btn_Yeni_Kayit.ImageList = this.ımageList1;
            this.btn_Yeni_Kayit.Location = new System.Drawing.Point(3, 7);
            this.btn_Yeni_Kayit.Name = "btn_Yeni_Kayit";
            this.btn_Yeni_Kayit.Size = new System.Drawing.Size(60, 25);
            this.btn_Yeni_Kayit.TabIndex = 10;
            this.btn_Yeni_Kayit.Text = "Yeni";
            this.btn_Yeni_Kayit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Yeni_Kayit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Yeni_Kayit.UseVisualStyleBackColor = false;
            this.btn_Yeni_Kayit.Click += new System.EventHandler(this.btn_Yeni_Kayit_Click);
            // 
            // btn_Filtrele
            // 
            this.btn_Filtrele.BackColor = System.Drawing.Color.Lavender;
            this.btn_Filtrele.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Filtrele.ForeColor = System.Drawing.Color.DarkBlue;
            this.btn_Filtrele.ImageKey = "funnel.png";
            this.btn_Filtrele.ImageList = this.ımageList1;
            this.btn_Filtrele.Location = new System.Drawing.Point(115, 171);
            this.btn_Filtrele.Name = "btn_Filtrele";
            this.btn_Filtrele.Size = new System.Drawing.Size(76, 34);
            this.btn_Filtrele.TabIndex = 8;
            this.btn_Filtrele.Text = "Filtrele";
            this.btn_Filtrele.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Filtrele.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Filtrele.UseVisualStyleBackColor = false;
            this.btn_Filtrele.Click += new System.EventHandler(this.btn_Filtrele_Click);
            // 
            // pnl_Islem
            // 
            this.pnl_Islem.Controls.Add(this.btn_Yazdir);
            this.pnl_Islem.Controls.Add(this.lbl_Liste_Adet);
            this.pnl_Islem.Controls.Add(this.btn_Sil);
            this.pnl_Islem.Controls.Add(this.btn_Detay);
            this.pnl_Islem.Controls.Add(this.btn_Yeni_Kayit);
            this.pnl_Islem.Location = new System.Drawing.Point(10, 27);
            this.pnl_Islem.Name = "pnl_Islem";
            this.pnl_Islem.Size = new System.Drawing.Size(940, 60);
            this.pnl_Islem.TabIndex = 18;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Width = 1017;
            // 
            // grd_Liste
            // 
            this.grd_Liste.AllowUserToAddRows = false;
            this.grd_Liste.AllowUserToDeleteRows = false;
            this.grd_Liste.AllowUserToResizeColumns = false;
            this.grd_Liste.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.grd_Liste.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grd_Liste.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_Liste.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grd_Liste.ColumnHeadersHeight = 50;
            this.grd_Liste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grd_Liste.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd_Liste.DefaultCellStyle = dataGridViewCellStyle2;
            this.grd_Liste.Location = new System.Drawing.Point(10, 95);
            this.grd_Liste.MultiSelect = false;
            this.grd_Liste.Name = "grd_Liste";
            this.grd_Liste.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grd_Liste.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grd_Liste.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grd_Liste.Size = new System.Drawing.Size(940, 490);
            this.grd_Liste.TabIndex = 14;
            this.grd_Liste.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grd_Liste_CellMouseDoubleClick);
            this.grd_Liste.Sorted += new System.EventHandler(this.grd_Liste_Sorted);
            // 
            // grp_Filtre
            // 
            this.grp_Filtre.BackColor = System.Drawing.Color.Transparent;
            this.grp_Filtre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grp_Filtre.Controls.Add(this.chk_Aktiflik);
            this.grp_Filtre.Controls.Add(this.chk_Aktiflik_Durumu);
            this.grp_Filtre.Controls.Add(this.chk_Soru);
            this.grp_Filtre.Controls.Add(this.label1);
            this.grp_Filtre.Controls.Add(this.txt_Soru);
            this.grp_Filtre.Controls.Add(this.cmb_Konu);
            this.grp_Filtre.Controls.Add(this.chk_Konu);
            this.grp_Filtre.Controls.Add(this.label13);
            this.grp_Filtre.Controls.Add(this.cmb_Ders);
            this.grp_Filtre.Controls.Add(this.chk_Ders);
            this.grp_Filtre.Controls.Add(this.btn_Temizle);
            this.grp_Filtre.Controls.Add(this.btn_Filtrele);
            this.grp_Filtre.Controls.Add(this.label3);
            this.grp_Filtre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.grp_Filtre.ForeColor = System.Drawing.Color.MidnightBlue;
            this.grp_Filtre.Location = new System.Drawing.Point(20, 15);
            this.grp_Filtre.Name = "grp_Filtre";
            this.grp_Filtre.Size = new System.Drawing.Size(300, 600);
            this.grp_Filtre.TabIndex = 23;
            this.grp_Filtre.TabStop = false;
            this.grp_Filtre.Text = "Filtreler";
            // 
            // chk_Aktiflik
            // 
            this.chk_Aktiflik.AutoSize = true;
            this.chk_Aktiflik.Location = new System.Drawing.Point(279, 143);
            this.chk_Aktiflik.Name = "chk_Aktiflik";
            this.chk_Aktiflik.Size = new System.Drawing.Size(15, 14);
            this.chk_Aktiflik.TabIndex = 6;
            this.chk_Aktiflik.UseVisualStyleBackColor = true;
            this.chk_Aktiflik.CheckedChanged += new System.EventHandler(this.chk_Aktiflik_CheckedChanged);
            // 
            // chk_Aktiflik_Durumu
            // 
            this.chk_Aktiflik_Durumu.AutoSize = true;
            this.chk_Aktiflik_Durumu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chk_Aktiflik_Durumu.ForeColor = System.Drawing.Color.White;
            this.chk_Aktiflik_Durumu.Location = new System.Drawing.Point(123, 143);
            this.chk_Aktiflik_Durumu.Name = "chk_Aktiflik_Durumu";
            this.chk_Aktiflik_Durumu.Size = new System.Drawing.Size(114, 20);
            this.chk_Aktiflik_Durumu.TabIndex = 7;
            this.chk_Aktiflik_Durumu.Text = "Aktiflik Durumu";
            this.chk_Aktiflik_Durumu.UseVisualStyleBackColor = true;
            // 
            // chk_Soru
            // 
            this.chk_Soru.AutoSize = true;
            this.chk_Soru.Location = new System.Drawing.Point(279, 85);
            this.chk_Soru.Name = "chk_Soru";
            this.chk_Soru.Size = new System.Drawing.Size(15, 14);
            this.chk_Soru.TabIndex = 4;
            this.chk_Soru.UseVisualStyleBackColor = true;
            this.chk_Soru.CheckedChanged += new System.EventHandler(this.chk_Soru_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(70, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 163;
            this.label1.Text = "Soru:";
            // 
            // txt_Soru
            // 
            this.txt_Soru.BackColor = System.Drawing.Color.Lavender;
            this.txt_Soru.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_Soru.ForeColor = System.Drawing.Color.DarkBlue;
            this.txt_Soru.Location = new System.Drawing.Point(123, 81);
            this.txt_Soru.Multiline = true;
            this.txt_Soru.Name = "txt_Soru";
            this.txt_Soru.Size = new System.Drawing.Size(150, 53);
            this.txt_Soru.TabIndex = 5;
            this.txt_Soru.TextChanged += new System.EventHandler(this.txt_Soru_TextChanged);
            // 
            // cmb_Konu
            // 
            this.cmb_Konu.BackColor = System.Drawing.Color.Lavender;
            this.cmb_Konu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Konu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_Konu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmb_Konu.ForeColor = System.Drawing.Color.DarkBlue;
            this.cmb_Konu.FormattingEnabled = true;
            this.cmb_Konu.Location = new System.Drawing.Point(123, 51);
            this.cmb_Konu.Name = "cmb_Konu";
            this.cmb_Konu.Size = new System.Drawing.Size(150, 24);
            this.cmb_Konu.TabIndex = 3;
            // 
            // grp_Liste
            // 
            this.grp_Liste.BackColor = System.Drawing.Color.Transparent;
            this.grp_Liste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grp_Liste.Controls.Add(this.grd_Liste);
            this.grp_Liste.Controls.Add(this.pnl_Islem);
            this.grp_Liste.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.grp_Liste.ForeColor = System.Drawing.Color.MidnightBlue;
            this.grp_Liste.Location = new System.Drawing.Point(340, 15);
            this.grp_Liste.Name = "grp_Liste";
            this.grp_Liste.Size = new System.Drawing.Size(965, 600);
            this.grp_Liste.TabIndex = 22;
            this.grp_Liste.TabStop = false;
            this.grp_Liste.Text = "Soru Listesi";
            // 
            // Soru_Listesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1324, 631);
            this.Controls.Add(this.grp_Filtre);
            this.Controls.Add(this.grp_Liste);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Soru_Listesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Soru Listesi:..";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Soru_Listesi_FormClosing);
            this.Load += new System.EventHandler(this.Soru_Listesi_Load);
            this.pnl_Islem.ResumeLayout(false);
            this.pnl_Islem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Liste)).EndInit();
            this.grp_Filtre.ResumeLayout(false);
            this.grp_Filtre.PerformLayout();
            this.grp_Liste.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_Ders;
        private System.Windows.Forms.Button btn_Temizle;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Yazdir;
        private System.Windows.Forms.ComboBox cmb_Ders;
        private System.Windows.Forms.Label lbl_Liste_Adet;
        private System.Windows.Forms.Button btn_Sil;
        private System.Windows.Forms.Button btn_Detay;
        private System.Windows.Forms.CheckBox chk_Konu;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn_Yeni_Kayit;
        private System.Windows.Forms.Button btn_Filtrele;
        private System.Windows.Forms.Panel pnl_Islem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridView grd_Liste;
        private System.Windows.Forms.GroupBox grp_Filtre;
        private System.Windows.Forms.ComboBox cmb_Konu;
        private System.Windows.Forms.GroupBox grp_Liste;
        private System.Windows.Forms.CheckBox chk_Soru;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Soru;
        private System.Windows.Forms.CheckBox chk_Aktiflik;
        private System.Windows.Forms.CheckBox chk_Aktiflik_Durumu;
    }
}