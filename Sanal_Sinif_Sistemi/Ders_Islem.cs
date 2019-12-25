using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sanal_Sinif_Sistemi
{
    public partial class Ders_Islem : Form
    {
        public Ders_Islem()
        {
            InitializeComponent();
        }

        Degiskenler degisken = new Degiskenler();
        Textbox_Kontrol txt_kontrol = new Textbox_Kontrol();
        private void Ders_Islemler_Load(object sender, EventArgs e)
        {
            try
            {
                if (degisken.get_set_yapilacak_islem == "guncelle_sil" && degisken.get_set_secilen_satir_id != 0)
                {
                    btn_Kaydet.Enabled = false;
                    btn_Duzelt.Enabled = true;
                    btn_Sil.Enabled = true;

                    using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                    {
                        var sorgu = context.Derslers.Where(x => x.Ders_ID == degisken.get_set_secilen_satir_id).FirstOrDefault();

                        if (sorgu != null)
                        {
                            txt_Ders_Adi.Text = sorgu.Ders_Adi;
                            txt_Aciklama.Text = sorgu.Aciklama;

                            if (sorgu.Aktiflik_Durumu == true) chk_Aktiflik_Durumu.Checked = true;
                            else chk_Aktiflik_Durumu.Checked = false;
                        }
                    }
                }
                else if (degisken.get_set_yapilacak_islem == "yeni_kayit")
                {
                    btn_Kaydet.Enabled = true;
                    btn_Duzelt.Enabled = false;
                    btn_Sil.Enabled = false;
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }

        }

        private void Ders_Islemler_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                degisken.get_set_yapilacak_islem = "listele";
                degisken.get_set_secilen_satir_id = 0;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Memory.FlushMemory(); }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Ders_Adi.Text.Trim() != "")
                {
                    using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                    {
                        Dersler _ders = new Dersler
                        {
                            Ders_Adi = txt_Ders_Adi.Text,
                            Aktiflik_Durumu = chk_Aktiflik_Durumu.Checked,
                            Aciklama = txt_Aciklama.Text
                        };

                        context.Derslers.InsertOnSubmit(_ders);
                        context.SubmitChanges();
                        MessageBox.Show("Kayıt Başarılı..");
                    }
                }
                else MessageBox.Show("Gerekli Alanları Doldurunz!");
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void btn_Duzelt_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Ders_Adi.Text.Trim() != "")
                {
                    using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                    {
                        var sorgu = context.Derslers.Single(x => x.Ders_ID == degisken.get_set_secilen_satir_id);
                        sorgu.Ders_Adi = txt_Ders_Adi.Text;
                        sorgu.Aktiflik_Durumu = chk_Aktiflik_Durumu.Checked;
                        sorgu.Aciklama = txt_Aciklama.Text;

                        context.SubmitChanges();
                        MessageBox.Show("Güncelleme Başarılı..");
                    }
                }
                else MessageBox.Show("Gerekli Alanları Doldurunz!");
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult secenek = MessageBox.Show("Seçilenleri Silmek İstediğinize Emin Misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (secenek == DialogResult.Yes)
                {
                    using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                    {
                        var sorgu = context.Derslers.SingleOrDefault(x => x.Ders_ID == degisken.get_set_secilen_satir_id);
                        sorgu.Aktiflik_Durumu = false;

                        context.SubmitChanges();
                        MessageBox.Show("Kayıt Silindi..");
                    }
                }
                else if (secenek == DialogResult.No)
                {
                    //Hayır seçeneğine tıklandığında çalıştırılacak kodlar
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Ders_Adi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_kontrol.buyukharf(txt_Ders_Adi);
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Aciklama_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_kontrol.buyukharf(txt_Aciklama);
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }
    }
}
