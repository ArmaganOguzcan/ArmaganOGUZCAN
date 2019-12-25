using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;

namespace Sanal_Sinif_Sistemi
{
    public partial class Analizler : Form
    {
        public Analizler()
        {
            InitializeComponent();
        }

        Degiskenler degisken = new Degiskenler();
        Grid_Islemler grid_islem = new Grid_Islemler();

        int ders_id = 0;
        int konu_id = 0;
        int test_id = 0;
        int ogr_id = 0;

        private void grafik()
        {
            try
            {
                if (ogr_id != 0 && ders_id != 0 && konu_id != 0 && test_id != 0)
                {
                    string ders = "";
                    string konu = "";
                    int konu_dogru = 0;
                    int konu_yanlis = 0;
                    int konu_puan = 0;
                    int konu_basari_yuzdesi = 0;
                    int test_dogru = 0;
                    int test_yanlis = 0;                    
                    int puan_genel_toplam = 0;
                    int dizi_adet = 0;

                    ArrayList konu_adi = new ArrayList();
                    ArrayList ders_adi = new ArrayList();
                    ArrayList soru_sayisi = new ArrayList();
                    ArrayList dogru_sayisi = new ArrayList();
                    ArrayList yanlis_sayisi = new ArrayList();
                    ArrayList basari_orani = new ArrayList();
                    ArrayList genel_basari_orani = new ArrayList();

                    //Konu ve test için analiz
                    using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                    {
                        ders = "";
                        konu = "";
                        konu_dogru = 0;
                        konu_yanlis = 0;
                        konu_puan = 0;
                        konu_basari_yuzdesi = 0;
                        puan_genel_toplam = 0;
                        dizi_adet = 0;
                        test_dogru = 0;
                        test_yanlis = 0;

                        var sorgu = from a in context.Test_Detays
                                    join b in context.Tests on a.Test_ID equals b.Test_ID
                                    join c in context.Sorus on a.Soru_ID equals c.Soru_ID
                                    join d in context.Konus on c.Konu_ID equals d.Konu_ID

                                    where a.Test_ID == test_id
                                    select new
                                    {
                                        a.Soru_ID,
                                        a.Cevap_Secenek,
                                        c.Dogru_Cevap,
                                        c.Konu_ID,
                                        d.Konu_Adi
                                    };

                        var groups = sorgu.GroupBy(x => x.Konu_ID);

                        foreach (var group in groups)
                        {
                            konu_dogru = 0;
                            konu_yanlis = 0;
                            foreach (var item in group)
                            {
                                konu = item.Konu_Adi.ToString();
                                if (item.Dogru_Cevap == item.Cevap_Secenek) konu_dogru++;
                                else konu_yanlis++;
                            }
                            konu_basari_yuzdesi = (100 * konu_dogru) / (konu_dogru + konu_yanlis);
                           
                            test_dogru += konu_dogru;
                            test_yanlis += konu_yanlis;

                            this.chrt_Test_Dogru_Yanlis.Titles.Clear();
                            this.chrt_Test_Dogru_Yanlis.Series.Clear();
                            this.chrt_Test_Dogru_Yanlis.Series.Add("Toplam");
                            this.chrt_Test_Dogru_Yanlis.Series.Add("Doğru");
                            this.chrt_Test_Dogru_Yanlis.Series.Add("Yanlış");
                            this.chrt_Test_Dogru_Yanlis.Series[0].Color = Color.Blue;
                            this.chrt_Test_Dogru_Yanlis.Series[1].Color = Color.Green;
                            this.chrt_Test_Dogru_Yanlis.Series[2].Color = Color.Red;

                            this.chrt_Test_Basari.Titles.Clear();
                            this.chrt_Test_Basari.Series.Clear();
                            this.chrt_Test_Basari.Series.Add("Başarı");
                            this.chrt_Test_Basari.Series[0].Color = Color.Yellow;

                            konu_adi.Add(konu);
                            soru_sayisi.Add(konu_dogru + konu_yanlis);
                            dogru_sayisi.Add(konu_dogru);
                            yanlis_sayisi.Add(konu_yanlis);
                            basari_orani.Add(konu_basari_yuzdesi);

                            dizi_adet++;
                        }
                        for (int i = 0; i < konu_adi.Count; i++)
                        {
                            this.chrt_Test_Dogru_Yanlis.Series[0].Points.AddXY(konu_adi[i].ToString(), double.Parse(soru_sayisi[i].ToString()));
                            this.chrt_Test_Dogru_Yanlis.Series[1].Points.AddXY(konu_adi[i].ToString(), double.Parse(dogru_sayisi[i].ToString()));
                            this.chrt_Test_Dogru_Yanlis.Series[2].Points.AddXY(konu_adi[i].ToString(), double.Parse(yanlis_sayisi[i].ToString()));

                            this.chrt_Test_Basari.Series[0].Points.AddXY(konu_adi[i].ToString(), double.Parse(basari_orani[i].ToString()));
                        }

                        chrt_Test_Dogru_Yanlis.Series[0].IsValueShownAsLabel = true;
                        chrt_Test_Dogru_Yanlis.Series[1].IsValueShownAsLabel = true;
                        chrt_Test_Dogru_Yanlis.Series[2].IsValueShownAsLabel = true;
                        chrt_Test_Basari.Series[0].IsValueShownAsLabel = true;

                        chrt_Test_Dogru_Yanlis.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                        chrt_Test_Basari.ChartAreas[0].AxisX.LabelStyle.Angle = 45;

                        lbl_Dogru.Text = test_dogru.ToString();
                        lbl_Yanlis.Text = test_yanlis.ToString();
                        lbl_Soru_Sayisi.Text = (test_dogru + test_yanlis).ToString();
                        lbl_Puan.Text = ((100 / (test_dogru + test_yanlis)) * test_dogru).ToString();
                        if (int.Parse(lbl_Puan.Text) >= 50) lbl_Basari_Durum.Text = "Başarılı";
                        else lbl_Basari_Durum.Text = "Başarısız";
                    }

                    //Genel ders için
                    using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                    {
                        ders = "";
                        konu = "";
                        konu_dogru = 0;
                        konu_yanlis = 0;
                        konu_puan = 0;
                        konu_basari_yuzdesi = 0;
                        puan_genel_toplam = 0;
                        dizi_adet = 0;
                        test_dogru = 0;
                        test_yanlis = 0;

                        //var sorgu = from a in context.Test_Detays
                        //            where a.Test.Ders_ID == ders_id && a.Test.Kullanici_ID == ogr_id

                        //            select new
                        //            {
                        //                a.Soru_ID,
                        //                a.Cevap_Secenek,
                        //                a.Soru.Dogru_Cevap,
                        //                a.Soru.Ders_ID,
                        //                a.Soru.Dersler.Ders_Adi
                        //            };

                        var sorgu = from a in context.Test_Detays
                                    join b in context.Tests on a.Test_ID equals b.Test_ID
                                    join c in context.Sorus on a.Soru_ID equals c.Soru_ID
                                    join d in context.Derslers on c.Ders_ID equals d.Ders_ID

                                    where b.Ders_ID == ders_id && b.Kullanici_ID == ogr_id
                                    select new
                                    {
                                        a.Soru_ID,
                                        a.Cevap_Secenek,
                                        b.Test_ID,
                                        b.Test_Adi,
                                        c.Dogru_Cevap,
                                        c.Ders_ID                                        
                                    };

                        var groups = sorgu.GroupBy(x => x.Test_ID);

                        foreach (var group in groups)
                        {
                            konu_dogru = 0;
                            konu_yanlis = 0;
                            foreach (var item in group)
                            {
                                ders = item.Test_Adi.ToString();
                                if (item.Dogru_Cevap == item.Cevap_Secenek) konu_dogru++;
                                else konu_yanlis++;
                            }
                            konu_puan = ((100 / (konu_dogru + konu_yanlis)) * konu_dogru);

                            puan_genel_toplam += konu_puan;

                            this.chrt_Genel_Basari.Titles.Clear();
                            this.chrt_Genel_Basari.Series.Clear();
                            this.chrt_Genel_Basari.Series.Add("Genel Başarı");
                            this.chrt_Genel_Basari.Series[0].Color = Color.Fuchsia;

                            ders_adi.Add(ders);
                            genel_basari_orani.Add(konu_puan);

                            dizi_adet++;
                        }
                        for (int i = 0; i <ders_adi.Count ; i++)
                        {
                            this.chrt_Genel_Basari.Series[0].Points.AddXY(ders_adi[i].ToString(), double.Parse(genel_basari_orani[i].ToString()));
                        }

                        chrt_Genel_Basari.Series[0].IsValueShownAsLabel = true;
                        chrt_Genel_Basari.ChartAreas[0].AxisX.LabelStyle.Angle = 45;

                        lbl_Ders_Ort.Text = (puan_genel_toplam / dizi_adet).ToString();
                    }
                }
                else MessageBox.Show("Eksik Seçim!");
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void Analizler_Load(object sender, EventArgs e)
        {
            try
            {
                using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                {
                    cmb_Ders.ValueMember = "Ders_ID";
                    cmb_Ders.DisplayMember = "Ders_Adi";
                    cmb_Ders.DataSource = context.Derslers.ToList();
                }

                if (degisken.get_set_yetki_id == 3)//Öğrenci Girişi
                {                    
                    ogr_id = degisken.get_set_kullanici_id;                    
                    
                    txt_Ogrenci.Text = degisken.get_set_kul_adi_soyadi;
                    test_id = degisken.get_set_son_test_id;
                    grp_Filtre.Enabled = false;

                    using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                    {
                        var sorgu = (from a in context.Test_Detays
                                     where a.Test_ID == test_id

                                     select new
                                     {
                                         a.Test.Dersler.Ders_Adi,
                                         a.Soru.Konu.Konu_Adi,
                                         a.Test.Test_Adi
                                     }).FirstOrDefault();

                        //var sorgu = from a in context.Test_Detays
                        //            join b in context.Tests on a.Test_ID equals b.Test_ID
                        //            join c in context.Sorus on a.Soru_ID equals c.Soru_ID
                        //            join d in context.Konus on c.Konu_ID equals d.Konu_ID
                        //            join f in context.Derslers on c.Ders_ID equals f.Ders_ID

                        //            where a.Test_ID == test_id

                        //            select new
                        //            {
                        //                f.Ders_Adi,
                        //                d.Konu_Adi,
                        //                b.Test_Adi
                        //            };
                        if (sorgu != null)
                        {
                            //foreach (var item in sorgu)
                            //{
                                cmb_Ders.DataBindings.Add("Text", sorgu, "Ders_Adi");
                                cmb_Konu.DataBindings.Add("Text", sorgu, "Konu_Adi");
                                cmb_Test.DataBindings.Add("Text", sorgu, "Test_Adi");
                            //}
                        }
                    }
                    grafik();
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void btn_Goster_Click(object sender, EventArgs e)
        {
            try
            {
                grafik();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void btn_Personel_Ara_Click(object sender, EventArgs e)
        {
            try
            {
                Kullanici_Listesi frm = new Kullanici_Listesi();
                degisken.get_set_yapilacak_islem = "listele_sec";
                frm.ShowDialog();
                if (degisken.get_set_secilen_satir_id != 0)
                {
                    ogr_id = degisken.get_set_secilen_satir_id;

                    using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                    {
                        var sorgu = context.Kullanicis.Where(x => x.Kullanici_ID == ogr_id).ToList();

                        foreach (var item in sorgu)
                        {
                            txt_Ogrenci.Text = item.Adi + " " + item.Soyadi;
                        }
                    }
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void Analizler_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                degisken.get_set_yapilacak_islem = "listele";
                degisken.get_set_secilen_satir_id = 0;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Memory.FlushMemory(); }
        }

        private void cmb_Ders_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Ders.SelectedIndex != -1)
                {
                    using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                    {
                        ders_id = Convert.ToInt16(cmb_Ders.SelectedValue.ToString());

                        cmb_Konu.ValueMember = "Konu_ID";
                        cmb_Konu.DisplayMember = "Konu_Adi";
                        cmb_Konu.DataSource = context.Konus.Where(x => x.Ders_ID == Convert.ToInt16(cmb_Ders.SelectedValue)).ToList();

                        if (ogr_id != 0)
                        {
                            cmb_Test.ValueMember = "Test_ID";
                            cmb_Test.DisplayMember = "Test_Adi";
                            cmb_Test.DataSource = context.Tests.Where(x => x.Ders_ID == Convert.ToInt16(cmb_Ders.SelectedValue) && x.Kullanici_ID == ogr_id).ToList();
                        }
                    }
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void cmb_Konu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                konu_id = Convert.ToInt16(cmb_Konu.SelectedValue.ToString());
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void cmb_Test_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                test_id = Convert.ToInt16(cmb_Test.SelectedValue.ToString());
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Ogrenci_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                {
                    cmb_Test.ValueMember = "Test_ID";
                    cmb_Test.DisplayMember = "Test_Adi";
                    cmb_Test.DataSource = context.Tests.Where(x => x.Ders_ID == Convert.ToInt16(cmb_Ders.SelectedValue) && x.Kullanici_ID == ogr_id).ToList();
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

    }
}
