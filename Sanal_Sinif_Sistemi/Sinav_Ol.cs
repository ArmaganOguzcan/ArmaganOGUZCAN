using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sanal_Sinif_Sistemi
{
    public partial class Sinav_Ol : Form
    {
        public Sinav_Ol()
        {
            InitializeComponent();
        }

        Degiskenler degisken = new Degiskenler();
        Grid_Islemler grid_islem = new Grid_Islemler();

        DateTime dt = DateTime.Now.AddHours(0).AddMinutes(59).AddSeconds(60);

        List<Soru> sorular = new List<Soru>();
        int secilen_soru_sirasi = 0;
        int[] secili_cevap = new int[50];
      
        private int[,] soru_adedi_hesapla(int[,] dizi)
        {
            int toplam_hata_orani = 0;
            int toplam_soru = 0;
            int[] gecici_hata = new int[dizi.GetLength(0)];
            int[,] sorulacak = new int[dizi.GetLength(0), 2];

            for (int i = 0; i < dizi.GetLength(0); i++)
            {
                gecici_hata[i] = (dizi[i, 2] * 100) / (dizi[i,1] + dizi[i,2]);
                toplam_hata_orani += gecici_hata[i];
            }

            int en_cok_miktar = 0;
            int en_cok_index = 0;
            for (int i = 0; i < dizi.GetLength(0); i++)
            {
                sorulacak[i, 0] = dizi[i, 0];//Konu
                sorulacak[i,1]= (int)Math.Round(gecici_hata[i] * 40.0 / toplam_hata_orani);//Soru Adet
                if (sorulacak[i, 1] >= en_cok_miktar)
                {
                    en_cok_miktar = sorulacak[i, 1];
                    en_cok_index = i;
                }                   
                toplam_soru += sorulacak[i, 1];
            }
            
            if (toplam_soru > 40) sorulacak[en_cok_index, 1] = sorulacak[en_cok_index, 1] - (toplam_soru-40);
            else if (toplam_soru < 40) sorulacak[en_cok_index, 1] = sorulacak[en_cok_index, 1] + (40 - toplam_soru);

            for (int i = 0; i < dizi.GetLength(0); i++)
            {
                sorulacak[i, 1] += 1;
            }
            return sorulacak;
        }

        private void cevap_yaz()
        {
            try
            {
                if (rd_Cevap_A.Checked) secili_cevap[secilen_soru_sirasi] = 1;
                else if (rd_Cevap_B.Checked) secili_cevap[secilen_soru_sirasi] = 2;
                else if (rd_Cevap_C.Checked) secili_cevap[secilen_soru_sirasi] = 3;
                else if (rd_Cevap_D.Checked) secili_cevap[secilen_soru_sirasi] = 4;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void cevap_isaretle()
        {
            try
            {
                if (secili_cevap[secilen_soru_sirasi] == 1) rd_Cevap_A.Checked = true;
                else if (secili_cevap[secilen_soru_sirasi] == 2) rd_Cevap_B.Checked = true;
                else if (secili_cevap[secilen_soru_sirasi] == 3) rd_Cevap_C.Checked = true;
                else if (secili_cevap[secilen_soru_sirasi] == 4) rd_Cevap_D.Checked = true;
                else
                {
                    rd_Cevap_A.Checked = false;
                    rd_Cevap_B.Checked = false;
                    rd_Cevap_C.Checked = false;
                    rd_Cevap_D.Checked = false;
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void soru_olustur()
        {
            try
            {
                for (int i = 1; i <= 50; i++)
                {
                    cmb_Soru.Items.Add("Soru-" + i.ToString());
                }

                using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                {
                    var sorgu = context.Tests.Where(x => x.Kullanici_ID == degisken.get_set_kullanici_id && x.Ders_ID == Convert.ToInt16(cmb_Ders.SelectedValue.ToString())).ToList();
                    var tum_ders_sorulari = context.Sorus.Where(x => x.Ders_ID == Convert.ToInt16(cmb_Ders.SelectedValue.ToString()) && x.Aktiflik_Durumu == true).ToList();
                    var konu_adedi = context.Konus.Where(x => x.Ders_ID == Convert.ToInt16(cmb_Ders.SelectedValue.ToString()) && x.Aktiflik_Durumu == true).ToList();

                    int[,] soru_adet = new int[konu_adedi.Count, 2];//Dersin Konu adedi kadar dizi oluştır 0->Konu_ID, 1-> Sorulacak Soru Adedi
                    int[] soru_id = new int[50];//rasgele 50 adet seçilen soruların Soru_ID'si


                    if (sorgu.Any())
                    {
                        int[,] dogru_yanlis_cevap = new int[konu_adedi.Count, 3];//0-> Konu_ID, 1-> Doğru adet, 2-> Yanlış adet

                        var sorgu2 = from a in context.Test_Detays
                                     join b in context.Tests on a.Test_ID equals b.Test_ID
                                     join c in context.Sorus on a.Soru_ID equals c.Soru_ID

                                     where b.Ders_ID == Convert.ToInt16(cmb_Ders.SelectedValue.ToString())

                                     select new
                                     {
                                         a.Soru_ID,
                                         a.Cevap_Secenek,
                                         c.Soru_Icerik,
                                         c.Dogru_Cevap,
                                         c.Konu_ID
                                     };

                        var groups = sorgu2.GroupBy(x => x.Konu_ID);

                        int konu = 0;
                        int dogru = 0;
                        int yanlis = 0;
                        int dizi_adet = 0;

                        foreach (var group in groups)
                        {
                            dogru = 0;
                            yanlis = 0;
                            foreach (var item in group)
                            {
                                konu = item.Konu_ID;
                                if (item.Dogru_Cevap == item.Cevap_Secenek) dogru++;
                                else yanlis++;
                            }
                            dogru_yanlis_cevap[dizi_adet, 0] = konu;
                            dogru_yanlis_cevap[dizi_adet, 1] = dogru;
                            dogru_yanlis_cevap[dizi_adet, 2] = yanlis;
                            dizi_adet++;
                        }

                        soru_adet = soru_adedi_hesapla(dogru_yanlis_cevap);
                    }
                    else
                    {
                        for (int i = 0; i < konu_adedi.Count; i++)
                        {
                            soru_adet[i, 0] = konu_adedi[i].Konu_ID;
                            soru_adet[i, 1] = 5;
                        }
                    }

                    Random rnd = new Random();
                    int sira = 0;

                    for (int i = 0; i < konu_adedi.Count; i++)
                    {
                        var tum_konu_sorulari = tum_ders_sorulari.Where(x => x.Konu_ID == Convert.ToInt16(soru_adet[i, 0])).ToList();
                        int sayac = 0;
                        while (sayac < soru_adet[i, 1])
                        {
                            int rastgele = rnd.Next(0, tum_konu_sorulari.Count());
                            if (Array.IndexOf(soru_id, tum_konu_sorulari[rastgele].Soru_ID) == -1)
                            {
                                soru_id[sira] = tum_konu_sorulari[rastgele].Soru_ID;
                                sayac++;
                                sira++;
                            }
                        }
                    }

                    foreach (var item in tum_ders_sorulari)
                    {
                        foreach (var item2 in soru_id)
                        {
                            if (item.Soru_ID == item2)
                            {
                                sorular.Add(item);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void sorudegistir()
        {
            try
            {
                txt_Adi.Text = sorular[secilen_soru_sirasi].Soru_Icerik;
                rd_Cevap_A.Text = sorular[secilen_soru_sirasi].Cevap_Metin_A;
                rd_Cevap_B.Text = sorular[secilen_soru_sirasi].Cevap_Metin_B;
                rd_Cevap_C.Text = sorular[secilen_soru_sirasi].Cevap_Metin_C;
                rd_Cevap_D.Text = sorular[secilen_soru_sirasi].Cevap_Metin_D;
                img_Soru.ImageLocation = sorular[secilen_soru_sirasi].Soru_Img;
                img_Cevap_A.ImageLocation = sorular[secilen_soru_sirasi].Cevap_Img_A;
                img_Cevap_B.ImageLocation = sorular[secilen_soru_sirasi].Cevap_Img_B;
                img_Cevap_C.ImageLocation = sorular[secilen_soru_sirasi].Cevap_Img_C;
                img_Cevap_D.ImageLocation = sorular[secilen_soru_sirasi].Cevap_Img_D;

                cevap_isaretle();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void Sinav_Ol_Load(object sender, EventArgs e)
        {
            try
            {
                using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                {
                    cmb_Ders.ValueMember = "Ders_ID";
                    cmb_Ders.DisplayMember = "Ders_Adi";
                    cmb_Ders.DataSource = context.Derslers.Where(x => x.Aktiflik_Durumu == true).ToList();

                    grp_Sivav.Enabled = false;
                    btn_Testi_Bitir.Enabled = false;
                    btn_Sonuc_Izle.Enabled = false;

                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (pbar_Sure.Value < pbar_Sure.Maximum) pbar_Sure.Value++;
                TimeSpan diff = dt.Subtract(DateTime.Now);
                lbl_Sayac.Text = string.Format("{0:00}:{1:00}:{2:00}", diff.Hours, diff.Minutes, diff.Seconds);
                if (dt < DateTime.Now) timer1.Stop();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void btn_Teste_Basla_Click(object sender, EventArgs e)
        {
            try
            {
                grp_Sivav.Enabled = true;
                btn_Testi_Bitir.Enabled = true;
                btn_Sonuc_Izle.Enabled = false;
                btn_Teste_Basla.Enabled = false;
                cmb_Ders.Enabled = false;

                soru_olustur();
                cmb_Soru.SelectedIndex = 0;
                timer1.Start();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void btn_Testi_Bitir_Click(object sender, EventArgs e)
        {
            try
            {
                using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                {
                    grp_Sivav.Enabled = false;
                    btn_Testi_Bitir.Enabled = false;
                    btn_Sonuc_Izle.Enabled = true;
                    btn_Teste_Basla.Enabled = false;
                    timer1.Stop();


                    //Test Bilgilerini ekleme
                    int test_adet = 0;
                    int test_id = 0;

                    var sorgu = context.Tests.Where(x => x.Kullanici_ID == Convert.ToInt16(degisken.get_set_kullanici_id) && x.Ders_ID == Convert.ToInt16(cmb_Ders.SelectedValue.ToString())).ToList();

                    if (sorgu.Count == 0) test_adet = 1;
                    else test_adet = sorgu.Count() + 1;

                    Test _test = new Test
                    {
                        Kullanici_ID = Convert.ToInt16(degisken.get_set_kullanici_id),
                        Ders_ID = Convert.ToInt16(cmb_Ders.SelectedValue.ToString()),
                        Test_Adi = cmb_Ders.SelectedText + " Test-" + test_adet.ToString()
                    };

                    context.Tests.InsertOnSubmit(_test);
                    context.SubmitChanges();
                    test_id = _test.Test_ID;
                    degisken.get_set_son_test_id = test_id;

                    if(chk_Otomatik_Cevapla.Checked)
                    {
                        Random rnd = new Random();
                        for (int i = 0; i < secili_cevap.Length; i++)
                        {
                            secili_cevap[i] = rnd.Next(1, 5);
                        }                     
                    }

                    //Soruları Ekleme
                    for (int i = 0; i < sorular.Count(); i++)
                    {
                        Test_Detay _testdetay = new Test_Detay
                        {
                            Test_ID = test_id,
                            Soru_ID = sorular[i].Soru_ID,
                            Cevap_Secenek = Convert.ToInt16(secili_cevap[i])
                        };
                        context.Test_Detays.InsertOnSubmit(_testdetay);
                        context.SubmitChanges();
                    }
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void btn_Sonuc_Izle_Click(object sender, EventArgs e)
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

        private void cmb_Soru_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                secilen_soru_sirasi = cmb_Soru.SelectedIndex;
                sorudegistir();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void btn_Ileri_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Soru.SelectedIndex <= 48)
                {
                    cevap_yaz();
                    cmb_Soru.SelectedIndex += 1;
                    btn_Ileri.Enabled = true;
                    btn_Geri.Enabled = true;
                }
                else { btn_Ileri.Enabled = false; }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Soru.SelectedIndex >= 1)
                {
                    cevap_yaz();
                    cmb_Soru.SelectedIndex -= 1;
                    btn_Geri.Enabled = true;
                    btn_Ileri.Enabled = true;
                }
                else { btn_Geri.Enabled = false; }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }
    }
}