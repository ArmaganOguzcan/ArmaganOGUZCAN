using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections;

namespace Sanal_Sinif_Sistemi
{
    public partial class Kullanici_Listesi : Form
    {
        public Kullanici_Listesi()
        {
            InitializeComponent();
        }


        Degiskenler degisken = new Degiskenler();
        Textbox_Kontrol txt_kontrol = new Textbox_Kontrol();
        Grid_Islemler grid_islem = new Grid_Islemler();

        private void listele()
        {
            try
            {
                //grd_Liste.Rows.Clear();

                using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                {
                    var sorgu = from a in context.Kullanicis
                                join b in context.Yetkis on a.Yetki_ID equals b.Yetki_ID

                                orderby a.TC_Kimlik_No ascending
                                select new
                                {
                                    a.Kullanici_ID,
                                    a.TC_Kimlik_No,
                                    a.Adi,
                                    a.Soyadi,
                                    b.Yetki_Adi,
                                    a.Aktiflik_Durumu,

                                    a.Kullanici_Adi,
                                    a.Kullanici_Sifre,
                                    a.Yetki_ID,
                                };

                    if (degisken.get_set_yapilacak_islem == "listele_sec") sorgu = sorgu.Where(x => x.Yetki_ID == 3);

                    if (chk_TC_Kimlik_No.Checked)
                    {
                        sorgu = sorgu.Where(s => s.TC_Kimlik_No.ToString() == txt_TC_Kimlik_No.Text);
                    }
                    if (chk_Adi.Checked)
                    {
                        sorgu = sorgu.Where(s => s.Adi.ToString().Contains(txt_Adi.Text));
                    }
                    if (chk_Soyadi.Checked)
                    {
                        sorgu = sorgu.Where(s => s.Soyadi.ToString().Contains(txt_Soyadi.Text));
                    }
                    if (chk_Kullanici_Adi.Checked)
                    {
                        sorgu = sorgu.Where(s => s.Kullanici_Adi.ToString() == txt_Kullanici_Adi.Text);
                    }
                    if (chk_Sifre.Checked)
                    {
                        sorgu = sorgu.Where(s => s.Kullanici_Sifre.ToString() == txt_Sifre.Text);
                    }
                    if (chk_Yetki.Checked)
                    {
                        sorgu = sorgu.Where(s => s.Yetki_ID.ToString() == cmb_Yetki.SelectedValue.ToString());
                    }
                    if (chk_Aktiflik.Checked)
                    {
                        sorgu = sorgu.Where(s => s.Aktiflik_Durumu == chk_Aktiflik.Checked);
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
            finally { Memory.FlushMemory(); }
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
                grd_Liste.Columns[2].Width = 120;// TC_Kimlik
                grd_Liste.Columns[3].Width = 100;// Adi
                grd_Liste.Columns[4].Width = 100;// Soyadı
                grd_Liste.Columns[5].Width = 90;// Yetki_Adi
                grd_Liste.Columns[3].Width = 70;// Aktiflik

                grd_Liste.Columns[0].HeaderText = "Seç";
                grd_Liste.Columns[1].HeaderText = "ID";
                grd_Liste.Columns[2].HeaderText = "TC Kimlik No";
                grd_Liste.Columns[3].HeaderText = "Adı";
                grd_Liste.Columns[4].HeaderText = "Soyadı";
                grd_Liste.Columns[5].HeaderText = "Yetki";
                grd_Liste.Columns[6].HeaderText = "Aktiflik";

                grd_Liste.Columns[0].Visible = true;
                //grd_Liste.Columns[1].Visible = true;
                grd_Liste.Columns[2].Visible = true;
                grd_Liste.Columns[3].Visible = true;
                grd_Liste.Columns[4].Visible = true;
                grd_Liste.Columns[5].Visible = true;
                grd_Liste.Columns[6].Visible = true;

                grid_islem.nesne_genislik(this, grd_Liste, grp_Liste, pnl_Islem);
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void filtre_temizle()
        {
            try
            {
                chk_TC_Kimlik_No.Checked = false;
                chk_Adi.Checked = false;
                chk_Soyadi.Checked = false;
                chk_Kullanici_Adi.Checked = false;
                chk_Sifre.Checked = false;
                chk_Yetki.Checked = false;
                chk_Aktiflik.Checked = false;

                txt_TC_Kimlik_No.Enabled = false;
                txt_Adi.Enabled = false;
                txt_Soyadi.Enabled = false;
                txt_Kullanici_Adi.Enabled = false;
                txt_Sifre.Enabled = false;
                cmb_Yetki.Enabled = false;
                chk_Aktiflik.Enabled = false;

                degisken.get_set_secilen_satir_id = 0;
                txt_TC_Kimlik_No.Text = "";
                txt_Adi.Text = "";
                txt_Soyadi.Text = "";
                txt_Kullanici_Adi.Text = "";
                txt_Sifre.Text = "";
                cmb_Yetki.SelectedIndex = 0;
                chk_Aktiflik.Checked = false;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Memory.FlushMemory(); }
        }

        private void Kullanici_Listesi_Load(object sender, EventArgs e)
        {
            try
            {
                using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                {
                    cmb_Yetki.ValueMember = "Yetki_ID";
                    cmb_Yetki.DisplayMember = "Yetki_Adi";
                    cmb_Yetki.DataSource =context.Yetkis.ToList();
                }

                filtre_temizle();

                if (degisken.get_set_yapilacak_islem == "listele")
                {
                    btn_Yeni_Kayit.Enabled = true;
                    btn_Detay.Enabled = true;
                    btn_Sil.Enabled = true;
                    btn_Yazdir.Enabled = true;
                }
                else if (degisken.get_set_yapilacak_islem == "listele_sec")
                {
                    btn_Yeni_Kayit.Enabled = false;
                    btn_Detay.Enabled = false;
                    btn_Sil.Enabled = false;
                    btn_Yazdir.Enabled = false;
                }

                listele();
                if (grd_Liste.RowCount != 0) grid_hücre_baslik();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void Kullanici_Listesi_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                degisken.get_set_yapilacak_islem = "listele";
                //degisken.get_set_secilen_satir_id = 0;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Memory.FlushMemory(); }
        }

        private void btn_Yeni_Kayit_Click(object sender, EventArgs e)
        {
            try
            {
                Kullanici_Islem frm_kullanici_islem = new Kullanici_Islem();

                degisken.get_set_yapilacak_islem = "yeni_kayit";
                frm_kullanici_islem.ShowDialog();
                listele();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void btn_Detay_Click(object sender, EventArgs e)
        {
            try
            {
                if (grd_Liste.CurrentRow != null)
                {
                    Kullanici_Islem frm_kullanici_islem = new Kullanici_Islem();

                    degisken.get_set_secilen_satir_id = Convert.ToInt32((grd_Liste.CurrentRow.Cells[1].Value));
                    degisken.get_set_yapilacak_islem = "guncelle_sil";
                    frm_kullanici_islem.ShowDialog();
                    listele();
                }
                else MessageBox.Show("Lüften Kayıt Seçiniz!");
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
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
                                var sorgu = context.Kullanicis.Single(x => x.Kullanici_ID == degisken.get_set_secilen_satir_id);
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
            finally {  }
        }

        private void btn_Temizle_Click(object sender, EventArgs e)
        {
            try
            {
                filtre_temizle();
                listele();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void btn_Yazdir_Click(object sender, EventArgs e)
        {
            try
            {
                Analizler frm = new Analizler();
                degisken.get_set_yapilacak_islem = "yazdir_Konu_Rapor";
                frm.ShowDialog();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void grd_Liste_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Kullanici_Islem frm_kullanici_islem = new Kullanici_Islem();

                degisken.get_set_secilen_satir_id = Convert.ToInt32((grd_Liste.CurrentRow.Cells[1].Value));
                if (degisken.get_set_yapilacak_islem == "listele")
                {
                    degisken.get_set_yapilacak_islem = "guncelle_sil";
                    frm_kullanici_islem.ShowDialog();
                    listele();
                }
                else if (degisken.get_set_yapilacak_islem == "listele_sec")
                {
                    this.Close();
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
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

        private void chk_TC_Kimlik_No_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk_TC_Kimlik_No.Checked) { txt_TC_Kimlik_No.Enabled = true; txt_TC_Kimlik_No.Focus(); }
                else txt_TC_Kimlik_No.Enabled = false;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void chk_Adi_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk_Adi.Checked) { txt_Adi.Enabled = true; txt_Adi.Focus(); }
                else txt_Adi.Enabled = false;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void chk_Soyadi_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk_Soyadi.Checked) { txt_Soyadi.Enabled = true; txt_Soyadi.Focus(); }
                else txt_Soyadi.Enabled = false;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void chk_Kullanici_Adi_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk_Kullanici_Adi.Checked) { txt_Kullanici_Adi.Enabled = true; txt_Kullanici_Adi.Focus(); }
                else txt_Kullanici_Adi.Enabled = false;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void chk_Sifre_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk_Sifre.Checked) { txt_Sifre.Enabled = true; txt_Sifre.Focus(); }
                else txt_Sifre.Enabled = false;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void chk_Yetki_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk_Yetki.Checked) { cmb_Yetki.Enabled = true; cmb_Yetki.Focus(); }
                else cmb_Yetki.Enabled = false;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void chk_Aktiflik_Durumu_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk_Aktiflik.Checked) { chk_Aktiflik_Durumu.Enabled = true; chk_Aktiflik_Durumu.Focus(); }
                else chk_Aktiflik_Durumu.Enabled = false;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void txt_Adi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_kontrol.buyukharf(txt_Adi);
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
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
    }
}
