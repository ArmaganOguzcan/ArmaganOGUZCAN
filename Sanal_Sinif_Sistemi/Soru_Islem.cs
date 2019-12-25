using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Sanal_Sinif_Sistemi
{
    public partial class Soru_Islem : Form
    {
        public Soru_Islem()
        {
            InitializeComponent();
        }

        Degiskenler degisken = new Degiskenler();
        Textbox_Kontrol txt_kontrol = new Textbox_Kontrol();
        private void soruolustur()
        {
            try
            {
                using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                {
                    Random rnd = new Random();
                    Int16 konu_id = 0;


                    for (int i = 1; i <= 4; i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            konu_id++;
                            for (int k = 1; k <= 20; k++)
                            {
                                int cvp = rnd.Next(1, 5);
                                Soru _soru = new Soru
                                {
                                    Ders_ID = Convert.ToInt16(i),
                                    Konu_ID = konu_id,
                                    Soru_Icerik = "Ders-" + i.ToString() + " Konu-" + j.ToString() + " Soru-" + k.ToString(),
                                    Soru_Img = "",
                                    Cevap_Metin_A = "Cevap-A",
                                    Cevap_Img_A = "",
                                    Cevap_Metin_B = "Cevap-B",
                                    Cevap_Img_B = "",
                                    Cevap_Metin_C = "Cevap-C",
                                    Cevap_Img_C = "",
                                    Cevap_Metin_D = "Cevap-D",
                                    Cevap_Img_D = "",
                                    Dogru_Cevap = Convert.ToInt16(cvp),
                                    Aktiflik_Durumu = true,
                                    Aciklama = ""
                                };

                                context.Sorus.InsertOnSubmit(_soru);
                                context.SubmitChanges();
                            }
                        }
                    }

                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void resim_kopyala(TextBox txt)
        {
            try
            {
                if (txt.Text != "")
                {
                    string hedef = Application.StartupPath + @"\Soru_Resimleri\";
                    string yeni_ad = cmb_Ders.SelectedText.ToString() + "_" + cmb_Konu.SelectedText.ToString() + "_" + Guid.NewGuid() + ".jpg";
                    string yeni_resim_yolu = hedef + yeni_ad;

                    File.Copy(txt.Text, yeni_resim_yolu);
                    txt.Text = yeni_resim_yolu;
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private string resim_sec()
        {
            string DosyaYolu = "";

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                // file.InitialDirectory = "C:"; // bu kod ile her zaman C bölümünü açacaktır. Yani açıldığında C bölümünü gösterecek.

                //file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //öncekinden farkı her açıldığında masaüstünü gösterecektir.
                // masaüstünü göstermek istiyorum ama kullanıcı adı farkından olmuyor diye düşünüyorsanız

                file.Filter = "Resim Dosyası(jpg) |*.jpg| Resim Dosyası (png)|*.png"; // dosya filtresi için bu kodu kullanıyoruz. Şuan sadece xlsx dosyalarını görecektir.
                file.FilterIndex = 1; // bu kod ile varsayılan olarak 1. filtre ile açılacaktır.
                file.RestoreDirectory = true;// bu kod ile her açıldığında açılan bir önceki klasörü açacaktır.
                file.CheckFileExists = false;   // bu kod dosya adı kısmına bir isim yazdığınızda dosya var mı yok mu kontrolünü yapar.
                file.Title = "Resim Dosyası Seçiniz..";    // pencerenin üstünde varsayılan olarak "Aç" yazar bu kod ile başlığı değiştirebiliriz.

                if (file.ShowDialog() == DialogResult.OK)// dosya seçildi ise
                {
                    // dosya seçildi ise
                    DosyaYolu = file.FileName;// seçilen dosyanın tüm yolunu verir
                                              //string DosyaAdi = file.SafeFileName;// seçilen dosyanın adını verir.
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }

            return DosyaYolu;
        }

        public Int16 dogrucevap(bool rd_a, bool rd_b, bool rd_c, bool rd_d)
        {
            if (rd_a == true) return 1;
            else if (rd_b == true) return 2;
            else if (rd_c == true) return 3;
            else if (rd_d == true) return 3;
            else return 1;
        }

        private void Soru_Giris_Load(object sender, EventArgs e)
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
                        cmb_Ders.ValueMember = "Ders_ID";
                        cmb_Ders.DisplayMember = "Ders_Adi";
                        cmb_Ders.DataSource = context.Derslers.Where(x => x.Aktiflik_Durumu == true).ToList();

                        cmb_Konu.ValueMember = "Konu_ID";
                        cmb_Konu.DisplayMember = "Konu_Adi";
                        //cmb_Konu.DataSource = db.Konus.ToList();

                        //lambda syntax yazılacak
                        var sorgu = from a in context.Sorus

                                    join b in context.Konus on a.Konu_ID equals b.Konu_ID
                                    join c in context.Derslers on b.Ders_ID equals c.Ders_ID
                                    where a.Soru_ID == degisken.get_set_secilen_satir_id
                                    //select new { a, b, c };
                                    select new
                                    {
                                        c.Ders_Adi,
                                        b.Konu_Adi,
                                        a,
                                        b,
                                        c
                                    };

                        if (sorgu != null)
                        {
                            foreach (var item in sorgu)
                            {
                                cmb_Ders.DataBindings.Add("Text", item, "Ders_Adi");
                                cmb_Konu.DataBindings.Add("Text", item, "Konu_Adi");

                                txt_Soru.Text = item.a.Soru_Icerik;
                                txt_Cevap_A.Text = item.a.Cevap_Metin_A;
                                txt_Img_A.Text = item.a.Cevap_Img_A;
                                txt_Cevap_B.Text = item.a.Cevap_Metin_B;
                                txt_Img_B.Text = item.a.Cevap_Img_B;
                                txt_Cevap_C.Text = item.a.Cevap_Metin_C;
                                txt_Img_C.Text = item.a.Cevap_Img_C;
                                txt_Cevap_D.Text = item.a.Cevap_Metin_D;
                                txt_Img_D.Text = item.a.Cevap_Img_D;
                                txt_Aciklama.Text = item.a.Aciklama;

                                if (item.a.Dogru_Cevap == 1) rd_Cevap_A.Checked = true;
                                else if (item.a.Dogru_Cevap == 2) rd_Cevap_B.Checked = true;
                                else if (item.a.Dogru_Cevap == 3) rd_Cevap_C.Checked = true;
                                else if (item.a.Dogru_Cevap == 4) rd_Cevap_D.Checked = true;

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
                    chk_Aktiflik_Durumu.Checked = true;

                    using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                    {
                        cmb_Ders.ValueMember = "Ders_ID";
                        cmb_Ders.DisplayMember = "Ders_Adi";
                        cmb_Ders.DataSource = context.Derslers.Where(x => x.Aktiflik_Durumu == true).ToList();
                    }
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void Soru_Islem_FormClosing(object sender, FormClosingEventArgs e)
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
                if (cmb_Ders.Text.ToString() != "" && cmb_Konu.Text.ToString() != "" && txt_Soru.Text.Trim() != "")
                {
                    using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                    {
                        Int16 cevap = dogrucevap(rd_Cevap_A.Checked,rd_Cevap_B.Checked,rd_Cevap_C.Checked,rd_Cevap_D.Checked);

                        resim_kopyala(txt_Img_Soru);
                        resim_kopyala(txt_Img_A);
                        resim_kopyala(txt_Img_B);
                        resim_kopyala(txt_Img_C);
                        resim_kopyala(txt_Img_D);

                        Soru _soru = new Soru
                        {
                            Konu_ID = Convert.ToInt16(cmb_Konu.SelectedValue.ToString()),
                            Soru_Icerik = txt_Soru.Text,
                            Soru_Img = txt_Img_Soru.Text,
                            Cevap_Metin_A = txt_Cevap_A.Text,
                            Cevap_Img_A = txt_Img_A.Text,
                            Cevap_Metin_B = txt_Cevap_B.Text,
                            Cevap_Img_B = txt_Img_B.Text,
                            Cevap_Metin_C = txt_Cevap_C.Text,
                            Cevap_Img_C = txt_Img_C.Text,
                            Cevap_Metin_D = txt_Cevap_D.Text,
                            Cevap_Img_D = txt_Img_D.Text,
                            Dogru_Cevap = cevap,
                            Aktiflik_Durumu = chk_Aktiflik_Durumu.Checked,
                            Aciklama = txt_Aciklama.Text
                        };

                        context.Sorus.InsertOnSubmit(_soru);
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
                if (cmb_Ders.Text.ToString() != "" && cmb_Konu.Text.ToString() != "" && txt_Soru.Text.Trim() != "")
                {
                    using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                    {
                        Int16 cevap = dogrucevap(rd_Cevap_A.Checked,rd_Cevap_B.Checked,rd_Cevap_C.Checked,rd_Cevap_D.Checked);

                        var sorgu = context.Sorus.Single(x => x.Soru_ID == degisken.get_set_secilen_satir_id);

                        sorgu.Konu_ID = Convert.ToInt16(cmb_Konu.SelectedValue.ToString());
                        sorgu.Soru_Icerik = txt_Soru.Text;
                        sorgu.Soru_Img = txt_Img_Soru.Text;
                        sorgu.Cevap_Metin_A = txt_Cevap_A.Text;
                        sorgu.Cevap_Img_A = txt_Img_A.Text;
                        sorgu.Cevap_Metin_B = txt_Cevap_B.Text;
                        sorgu.Cevap_Img_B = txt_Img_B.Text;
                        sorgu.Cevap_Metin_C = txt_Cevap_C.Text;
                        sorgu.Cevap_Img_C = txt_Img_C.Text;
                        sorgu.Cevap_Metin_D = txt_Cevap_D.Text;
                        sorgu.Cevap_Img_D = txt_Img_D.Text;
                        sorgu.Dogru_Cevap = cevap;
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
                        /*
                        //I. Yol Linq Metot
                        var sorgu = context.Sorus.Where(x => x.Soru_ID==degisken.get_set_secilen_satir_id).ToList();
                        sorgu.ForEach(a => a.Soru_Aktiflik = false);
                        */

                        /*
                        //II.Yol Linq Metot
                        var sorgu = context.Sorus.Where(x => x.Soru_ID == degisken.get_set_secilen_satir_id).FirstOrDefault();
                        sorgu.Soru_Aktiflik = false;
                        */


                        //III.Yol Linq Metot
                        var sorgu = context.Sorus.SingleOrDefault(x => x.Soru_ID == degisken.get_set_secilen_satir_id);
                        sorgu.Aktiflik_Durumu = false;


                        /*
                        // IV. Yol Query Metot
                        var sorgu = (from a in context.Sorus
                                     where a.Soru_ID == degisken.get_set_secilen_satir_id
                                     select a).ToList();

                        foreach (var item in sorgu)
                        {
                            item.Soru_Aktiflik = false;
                        }
                        */

                        /*
                        //V. Yol Query Metot
                        Soru sorgu = (from a in context.Sorus
                                     where a.Soru_ID == degisken.get_set_secilen_satir_id
                                     select a).Single();

                        sorgu.Soru_Aktiflik = false;
                        */

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

        private void cmb_Ders_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Ders.SelectedIndex != -1)
                {
                    using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                    {

                        //I. Yol LAMBADA
                        cmb_Konu.ValueMember = "Konu_ID";
                        cmb_Konu.DisplayMember = "Konu_Adi";
                        cmb_Konu.DataSource = context.Konus.Where(x => x.Aktiflik_Durumu == true && x.Ders_ID == Convert.ToInt16(cmb_Ders.SelectedValue)).ToList();

                        //II. Yol
                        //var sorgu = from p in context.Konus
                        //            where p.Ders_ID == Convert.ToInt16(cmb_Ders.SelectedValue)
                        //            select p;
                        //cmb_Konu.ValueMember = "Konu_ID";
                        //cmb_Konu.DisplayMember = "Konu_Adi";
                        //cmb_Konu.DataSource = sorgu.ToList();
                    }
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Soru_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_kontrol.buyukharf(txt_Soru);
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Cevap_A_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_kontrol.buyukharf(txt_Cevap_A);
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Cevap_B_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_kontrol.buyukharf(txt_Cevap_B);
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Cevap_C_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_kontrol.buyukharf(txt_Cevap_C);
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Cevap_D_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_kontrol.buyukharf(txt_Cevap_D);
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

        private void txt_Img_Soru_Sec_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Img_Soru.Text = resim_sec();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Img_A_Sec_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Img_A.Text = resim_sec();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Img_B_Sec_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Img_B.Text = resim_sec();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Img_C_Sec_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Img_C.Text = resim_sec();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Img_D_Sec_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Img_D.Text = resim_sec();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Img_Soru_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Img_Soru.Text = "";
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Img_A_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Img_A.Text = "";
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Img_B_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Img_B.Text = "";
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Img_C_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Img_C.Text = "";
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Img_D_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Img_D.Text = "";
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                soruolustur();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }
    }
}
