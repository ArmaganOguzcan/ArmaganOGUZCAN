using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sanal_Sinif_Sistemi
{
    public partial class Kullanici_Giris : Form
    {
        public Kullanici_Giris()
        {
            InitializeComponent();
        }

        Degiskenler degisken = new Degiskenler();
        Anasayfa frm_anasayfa = new Anasayfa();

        public bool kullanici_dogrula(string kAdi, string kSifre)
        {
            using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
            {
                var sorgu = context.Kullanicis.Where(x => x.Kullanici_Adi == kAdi && x.Kullanici_Sifre == kSifre && x.Aktiflik_Durumu == true).FirstOrDefault();

                if (sorgu != null)
                {                    
                    degisken.get_set_kullanici_id = sorgu.Kullanici_ID;
                    degisken.get_set_yetki_id = sorgu.Yetki_ID;
                    degisken.get_set_kul_adi_soyadi = sorgu.Adi + " " + sorgu.Soyadi;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void Kullanici_Giris_Load(object sender, EventArgs e)
        {
            try
            {
                degisken.get_set_kullanici_id = 0;
                degisken.get_set_yetki_id = 0;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Memory.FlushMemory(); }
        }

        private void Kullanici_Giris_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (degisken.get_set_kullanici_id == 0 && degisken.get_set_yetki_id == 0)
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Memory.FlushMemory(); }
        }

        private void btn_Giris_Click(object sender, EventArgs e)
        {
            try
            {
                if (kullanici_dogrula(txt_Kul_Adi.Text.Trim(), txt_Kul_Sifre.Text.Trim()))
                {
                    txt_Kul_Adi.Text = "";
                    txt_Kul_Sifre.Text = "";
                    MessageBox.Show("Hoşgeldiniz::..");
                    this.Close();
                }
                else
                {
                    txt_Kul_Adi.Text = "";
                    txt_Kul_Sifre.Text = "";
                    MessageBox.Show("Hatalı Giriş!!");
                }                
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }
    }
}
