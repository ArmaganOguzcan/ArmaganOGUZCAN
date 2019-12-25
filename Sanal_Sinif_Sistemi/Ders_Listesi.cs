﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sanal_Sinif_Sistemi
{
    public partial class Ders_Listesi : Form
    {
        public Ders_Listesi()
        {
            InitializeComponent();
        }

        Degiskenler degisken = new Degiskenler();
        Grid_Islemler grid_islem = new Grid_Islemler();
        Textbox_Kontrol txt_kontrol = new Textbox_Kontrol();

        //private dynamic sorgu_deneme(DataClasses_Sanal_SinifDataContext context)
        //{           
        //        return context.Derslers.OrderBy(x => x.Ders_Adi).Select(x => new
        //        {
        //            x.Ders_ID,
        //            x.Ders_Adi,
        //            x.Aktiflik_Durumu
        //        });

        //}
        private void listele()
        {
            try
            {
                //grd_Liste.Rows.Clear();

                
                //IQueryable sorgu = null;
                using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                {
                    //List<Dersler> sorgu = sorgu_deneme(context).toList();
                    var sorgu = context.Derslers.OrderBy(x => x.Ders_Adi).Select(x => new
                    {
                        x.Ders_ID,
                        x.Ders_Adi,
                        x.Aktiflik_Durumu
                    });

                    //II. Yol
                    //sorgu = from a in context.Derslers
                    //orderby a.Ders_Adi ascending
                    //select a;


                    if (chk_Ders.Checked)
                    {
                        sorgu = sorgu.Where(s => s.Ders_Adi.Contains(txt_Ders_Adi.Text));
                    }

                    if (chk_Aktiflik.Checked)
                    {
                        sorgu = sorgu.Where(s => s.Aktiflik_Durumu == chk_Aktiflik_Durumu.Checked);
                    }

                    if (sorgu.Count() == 0) MessageBox.Show("Kayıt Bulunamadı");
                    else
                    {
                        degisken.get_set_rapor_sorgu = sorgu;
                        grd_Liste.DataSource = sorgu;

                        grid_islem.satir_numarasi(grd_Liste);
                        grid_islem.grid_arka_renk(grd_Liste);
                    }
                }

                if (grd_Liste.Rows.Count == 1) grid_hücre_baslik();
                lbl_Liste_Adet.Text = grd_Liste.Rows.Count + " Adet Veri Listelendi";
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void grid_hücre_baslik()
        {
            try
            {
                for (int i = 0; i < grd_Liste.ColumnCount; i++)
                {
                    grd_Liste.Columns[i].Visible = false;
                }

                grd_Liste.Columns[0].Width = 40;// seçme checkbox
                grd_Liste.Columns[1].Width = 50;// id
                grd_Liste.Columns[2].Width = 150;// Ders Adı
                grd_Liste.Columns[3].Width = 70;// Aktiflik

                grd_Liste.Columns[0].HeaderText = "Seç";
                grd_Liste.Columns[1].HeaderText = "ID";
                grd_Liste.Columns[2].HeaderText = "Ders";
                grd_Liste.Columns[3].HeaderText = "Aktiflik";

                grd_Liste.Columns[0].Visible = true;
                //grd_Liste.Columns[1].Visible = true;
                grd_Liste.Columns[2].Visible = true;
                grd_Liste.Columns[3].Visible = true;

                grid_islem.nesne_genislik(this, grd_Liste, grp_Liste, pnl_Islem);
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void filtre_temizle()
        {
            try
            {
                chk_Ders.Checked = false;
                chk_Aktiflik.Checked = false;

                txt_Ders_Adi.Enabled = false;
                chk_Aktiflik_Durumu.Enabled = false;

                degisken.get_set_secilen_satir_id = 0;
                txt_Ders_Adi.Text = "";
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void Ders_Listesi_Load(object sender, EventArgs e)
        {
            try
            {
                filtre_temizle();

                if (degisken.get_set_yapilacak_islem == "listele")
                {
                    btn_Yeni_Kayit.Enabled = true;
                    btn_Detay.Enabled = true;
                    btn_Sil.Enabled = true;
                    btn_Yazdir.Enabled = true;
                }

                listele();
                if (grd_Liste.RowCount != 0) grid_hücre_baslik();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void Ders_Listesi_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                degisken.get_set_yapilacak_islem = "listele";
                degisken.get_set_secilen_satir_id = 0;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Memory.FlushMemory(); }
        }

        private void btn_Yeni_Kayit_Click(object sender, EventArgs e)
        {
            try
            {
                degisken.get_set_yapilacak_islem = "yeni_kayit";
                Ders_Islem frm_ders_islem = new Ders_Islem();
                frm_ders_islem.ShowDialog();
                listele();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void btn_Detay_Click(object sender, EventArgs e)
        {
            try
            {
                if (grd_Liste.CurrentRow != null)
                {
                    degisken.get_set_secilen_satir_id = Convert.ToInt32((grd_Liste.CurrentRow.Cells[1].Value));
                    degisken.get_set_yapilacak_islem = "guncelle_sil";
                    Ders_Islem frm_ders_islem = new Ders_Islem();
                    frm_ders_islem.ShowDialog();
                    listele();
                }
                else MessageBox.Show("Lüften Kayıt Seçiniz!");
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList secili_elemanlar = new ArrayList();
                secili_elemanlar.Clear();

                for (int i = 0; i < grd_Liste.RowCount; i++)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)grd_Liste.Rows[i].Cells[0];

                    if (Convert.ToBoolean(ch1.Value) == true)
                    {
                        secili_elemanlar.Add(Convert.ToInt32(grd_Liste.Rows[i].Cells[1].Value.ToString()));
                    }
                }

                if (secili_elemanlar.Count != 0)
                {
                    DialogResult secenek = MessageBox.Show("Seçilenleri Silmek İstediğinize Emin Misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (secenek == DialogResult.Yes)
                    {
                        int adet_baslangic = grd_Liste.RowCount;

                        using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                        {
                            foreach (var item in secili_elemanlar)
                            {
                                Dersler sorgu = context.Derslers.Single(x => x.Ders_ID == degisken.get_set_secilen_satir_id);
                                sorgu.Aktiflik_Durumu = false;
                                context.SubmitChanges();
                            }
                        }
                        listele();

                        int adet_bitis = grd_Liste.RowCount;
                        if (adet_baslangic - adet_bitis != 0) MessageBox.Show(adet_baslangic - adet_bitis + " Adet Kayıt Silindi..");
                    }
                    else if (secenek == DialogResult.No)
                    {
                        //Hayır seçeneğine tıklandığında çalıştırılacak kodlar
                    }
                }
                else MessageBox.Show("Lüften Kayıt Seçiniz!");
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void btn_Filtrele_Click(object sender, EventArgs e)
        {
            try
            {
                listele();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void btn_Temizle_Click(object sender, EventArgs e)
        {
            try
            {
                filtre_temizle();
                listele();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void btn_Yazdir_Click(object sender, EventArgs e)
        {
            try
            {
                Analizler frm = new Analizler();
                degisken.get_set_yapilacak_islem = "yazdir_Ders_Rapor";
                frm.ShowDialog();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void grd_Liste_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                degisken.get_set_secilen_satir_id = Convert.ToInt32((grd_Liste.CurrentRow.Cells[1].Value));
                if (degisken.get_set_yapilacak_islem == "listele")
                {
                    degisken.get_set_yapilacak_islem = "guncelle_sil";
                    Ders_Islem frm_ders_islem = new Ders_Islem();
                    frm_ders_islem.ShowDialog();
                    listele();
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void grd_Liste_Sorted(object sender, EventArgs e)
        {
            try
            {
                grid_islem.satir_numarasi(grd_Liste);
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void chk_Ders_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk_Ders.Checked) { txt_Ders_Adi.Enabled = true; txt_Ders_Adi.Focus(); }
                else txt_Ders_Adi.Enabled = false;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void chk_Aktiflik_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk_Aktiflik.Checked) { chk_Aktiflik_Durumu.Enabled = true; chk_Aktiflik_Durumu.Focus(); }
                else chk_Aktiflik_Durumu.Enabled = false;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void txt_Ders_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_kontrol.buyukharf(txt_Ders_Adi);
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }
    }
}
