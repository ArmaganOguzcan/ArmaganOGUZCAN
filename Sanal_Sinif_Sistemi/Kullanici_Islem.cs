using System;
using System.Linq;
using System.Windows.Forms;

namespace Sanal_Sinif_Sistemi
{
    public partial class Kullanici_Islem : Form
    {
        public Kullanici_Islem()
        {
            InitializeComponent();
        }

        Degiskenler degisken = new Degiskenler();
        Textbox_Kontrol txt_kontrol = new Textbox_Kontrol();
        private void Kullanici_Islem_Load(object sender, EventArgs e)
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
                        cmb_Yetki.ValueMember = "Yetki_ID";
                        cmb_Yetki.DisplayMember = "Yetki_Adi";
                        cmb_Yetki.DataSource = context.Yetkis.ToList();

                        var sorgu = from a in context.Kullanicis
                                    join b in context.Yetkis on a.Yetki_ID equals b.Yetki_ID
                                    where a.Kullanici_ID == degisken.get_set_secilen_satir_id

                                    select new
                                    {
                                        a,
                                        b.Yetki_Adi
                                    };

                        if (sorgu != null)
                        {
                            foreach (var item in sorgu)
                            {
                                cmb_Yetki.DataBindings.Add("Text", item, "Yetki_Adi");

                                txt_TC_Kimlik_No.Text = item.a.TC_Kimlik_No;
                                txt_Adi.Text = item.a.Kullanici_Adi;
                                txt_Soyadi.Text = item.a.Soyadi;
                                txt_Kul_Adi.Text = item.a.Kullanici_Adi;
                                txt_Sifre.Text = item.a.Kullanici_Sifre.ToString();
                                txt_Aciklama.Text = item.a.Aciklama;

                                if (item.a.Aktiflik_Durumu == true) chk_Aktiflik_Durumu.Checked = true;
                                else chk_Aktiflik_Durumu.Checked = false;
                            }
                        }
                    }
                }
                else if (degisken.get_set_yapilacak_islem == "yeni_kayit")
                {
                    btn_Kaydet.Enabled = true;
                    btn_Duzelt.Enabled = false;
                    btn_Sil.Enabled = false;

                    using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                    {
                        cmb_Yetki.ValueMember = "Yetki_ID";
                        cmb_Yetki.DisplayMember = "Yetki_Adi";
                        cmb_Yetki.DataSource = context.Yetkis.ToList();
                    }
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void Kullanici_Islem_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                degisken.get_set_yapilacak_islem = "listele";
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Memory.FlushMemory(); }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Kul_Adi.Text.Trim() != "" && txt_Sifre.Text.Trim() != "" && (txt_Sifre.Text.Trim() == txt_Sifre_Tekrar.Text.Trim()))
                {
                    using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                    {
                        Kullanici _Kullanici = new Kullanici
                        {
                            Yetki_ID = Convert.ToInt16(cmb_Yetki.SelectedValue.ToString()),
                            TC_Kimlik_No=txt_TC_Kimlik_No.Text,
                            Adi = txt_Adi.Text,
                            Soyadi = txt_Soyadi.Text,
                            Kullanici_Adi=txt_Kul_Adi.Text,
                            Kullanici_Sifre=txt_Sifre.Text,
                            Aktiflik_Durumu = chk_Aktiflik_Durumu.Checked,
                            Aciklama = txt_Aciklama.Text
                        };

                        context.Kullanicis.InsertOnSubmit(_Kullanici);
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
                if (txt_Kul_Adi.Text.Trim() != "" && txt_Sifre.Text.Trim() != "" && (txt_Sifre.Text.Trim() == txt_Sifre_Tekrar.Text.Trim()))
                {
                    using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                    {
                        var sorgu = context.Kullanicis.Single(x => x.Kullanici_ID == degisken.get_set_secilen_satir_id);

                        sorgu.Yetki_ID = Convert.ToInt16(cmb_Yetki.SelectedValue.ToString());
                        sorgu.TC_Kimlik_No = txt_TC_Kimlik_No.Text;
                        sorgu.Adi = txt_Adi.Text;
                        sorgu.Soyadi = txt_Soyadi.Text;
                        sorgu.Kullanici_Adi = txt_Kul_Adi.Text;
                        sorgu.Kullanici_Sifre = txt_Sifre.Text;
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
                        var sorgu = context.Kullanicis.Single(x => x.Kullanici_ID == degisken.get_set_secilen_satir_id);
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

        private void txt_Adi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_kontrol.buyukharf(txt_Adi);
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Soyadi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_kontrol.buyukharf(txt_Soyadi);
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
