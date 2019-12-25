using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sanal_Sinif_Sistemi
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        Degiskenler degisken = new Degiskenler();

        private void login()
        {
            try
            {
                Image img1 = Image.FromFile(Path.Combine(Application.StartupPath, "Site_Resimleri\\sinav_ol_1.png"));
                Image img2 = Image.FromFile(Path.Combine(Application.StartupPath, "Site_Resimleri\\soru_gir_1.png"));
                Image img3 = Image.FromFile(Path.Combine(Application.StartupPath, "Site_Resimleri\\sinav_ol_2.png"));
                Image img4 = Image.FromFile(Path.Combine(Application.StartupPath, "Site_Resimleri\\soru_gir_2.png"));

                Kullanici_Giris frm = new Kullanici_Giris();
                degisken.get_set_yetki_id = 0;
                degisken.get_set_kullanici_id = 0;
                this.Visible = false;
                frm.ShowDialog();
                this.Visible = true;


                if (degisken.get_set_yetki_id == 1)//yönetici
                {
                    btn_Soru_Giris.BackgroundImage = img2;
                    btn_Sinav_Ol.BackgroundImage = img1;
                    btn_Sinav_Ol.Enabled = true;
                    btn_Soru_Giris.Enabled = true;

                    ders_bilgileri_ToolStripMenuItem.Visible = true;
                    konu_bilgileri_ToolStripMenuItem.Visible = true;
                    analizler_ToolStripMenuItem.Visible = true;
                    yedekleme_ToolStripMenuItem.Visible = true;
                    kullanicilar_ToolStripMenuItem.Visible = true;
                    kullanici_degistir_ToolStripMenuItem.Visible = true;

                    lbl_Hosgeldin.Top = 70;
                    lbl_kullanici.Top = 70;
                }
                else if (degisken.get_set_yetki_id == 2)//öğretmen
                {
                    btn_Soru_Giris.BackgroundImage = img2;
                    btn_Sinav_Ol.BackgroundImage = img3;
                    btn_Sinav_Ol.Enabled = false;
                    btn_Soru_Giris.Enabled = true;

                    ders_bilgileri_ToolStripMenuItem.Visible = false;
                    konu_bilgileri_ToolStripMenuItem.Visible = false;
                    analizler_ToolStripMenuItem.Visible = true;
                    yedekleme_ToolStripMenuItem.Visible = false;
                    kullanicilar_ToolStripMenuItem.Visible = false;
                    kullanici_degistir_ToolStripMenuItem.Visible = true;

                    lbl_Hosgeldin.Top = 50;
                    lbl_kullanici.Top = 50;
                }
                else if (degisken.get_set_yetki_id == 3)//öğrenci
                {
                    btn_Soru_Giris.BackgroundImage = img4;
                    btn_Sinav_Ol.BackgroundImage = img1;
                    btn_Sinav_Ol.Enabled = true;
                    btn_Soru_Giris.Enabled = false;

                    ders_bilgileri_ToolStripMenuItem.Visible = false;
                    konu_bilgileri_ToolStripMenuItem.Visible = false;
                    analizler_ToolStripMenuItem.Visible = false;
                    yedekleme_ToolStripMenuItem.Visible = false;
                    kullanicilar_ToolStripMenuItem.Visible = false;
                    kullanici_degistir_ToolStripMenuItem.Visible = true;

                    lbl_Hosgeldin.Top = 50;
                    lbl_kullanici.Top = 50;
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            try
            {
                login();
                lbl_kullanici.Text = degisken.get_set_kul_adi_soyadi;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void btn_Sinav_Ol_Click(object sender, EventArgs e)
        {
            try
            {
                Sinav_Ol frm = new Sinav_Ol();
                frm.ShowDialog();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void btn_Soru_Giris_Click(object sender, EventArgs e)
        {
            try
            {
                Soru_Listesi frm = new Soru_Listesi();
                degisken.get_set_yapilacak_islem = "listele";
                frm .ShowDialog();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void btn_Cikis_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ders_bilgileri_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Ders_Listesi frm = new Ders_Listesi();

                degisken.get_set_yapilacak_islem = "listele";
                frm.ShowDialog();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void konu_bilgileri_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Konu_Listesi frm = new Konu_Listesi();

                degisken.get_set_yapilacak_islem = "listele";
                frm.ShowDialog();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void analizler_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Analizler frm = new Analizler();

                degisken.get_set_yapilacak_islem = "listele";
                frm.ShowDialog();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void yedekleme_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Yedekleme_Islem frm = new Yedekleme_Islem();

                degisken.get_set_yapilacak_islem = "yedekleme";
                frm.ShowDialog();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void kullanicilar_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Kullanici_Listesi frm = new Kullanici_Listesi();

                degisken.get_set_yapilacak_islem = "listele";
                frm.ShowDialog();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void kullanici_degistir_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                login();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }
    }
}
