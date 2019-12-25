using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sanal_Sinif_Sistemi
{
    public partial class Soru_Listesi : Form
    {
        public Soru_Listesi()
        {
            InitializeComponent();
        }

        Degiskenler degisken = new Degiskenler();
        Grid_Islemler grid_islem = new Grid_Islemler();
        Textbox_Kontrol txt_kontrol = new Textbox_Kontrol();
        private void listele()
        {
            try
            {
                //grd_Liste.Rows.Clear();

                using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                {
                    var sorgu = from a in context.Sorus
                                join b in context.Konus on a.Konu_ID equals b.Konu_ID
                                join c in context.Derslers on b.Ders_ID equals c.Ders_ID

                                orderby a.Soru_Tarihi ascending
                                select new
                                {
                                    a.Soru_ID,
                                    c.Ders_Adi,
                                    b.Konu_Adi,
                                    a.Soru_Icerik,
                                    a.Aktiflik_Durumu,

                                    b.Konu_ID,
                                    c.Ders_ID
                                };

                    if (chk_Ders.Checked)
                    {
                        sorgu = sorgu.Where(s => s.Ders_ID.ToString() == cmb_Ders.SelectedValue.ToString());
                    }
                    if (chk_Konu.Checked)
                    {
                        sorgu = sorgu.Where(s => s.Konu_ID.ToString() == cmb_Konu.SelectedValue.ToString());
                    }
                    if (chk_Soru.Checked)
                    {
                        sorgu = sorgu.Where(s => s.Soru_Icerik.ToString().Contains(txt_Soru.Text));
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
                grd_Liste.Columns[3].Width = 250;// Konu Adı
                grd_Liste.Columns[4].Width = 350;// Soru
                grd_Liste.Columns[5].Width = 70;// Aktiflik

                grd_Liste.Columns[0].HeaderText = "Seç";
                grd_Liste.Columns[1].HeaderText = "ID";
                grd_Liste.Columns[2].HeaderText = "Ders";
                grd_Liste.Columns[3].HeaderText = "Konu";
                grd_Liste.Columns[4].HeaderText = "Soru";
                grd_Liste.Columns[5].HeaderText = "Aktiflik";

                grd_Liste.Columns[0].Visible = true;
                //grd_Liste.Columns[1].Visible = true;
                grd_Liste.Columns[2].Visible = true;
                grd_Liste.Columns[3].Visible = true;
                grd_Liste.Columns[4].Visible = true;
                grd_Liste.Columns[5].Visible = true;

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
                chk_Konu.Checked = false;
                chk_Soru.Checked = false;
                chk_Aktiflik.Checked = false;

                cmb_Ders.Enabled = false;
                cmb_Konu.Enabled = false;
                txt_Soru.Enabled = false;
                chk_Aktiflik_Durumu.Enabled = false;

                degisken.get_set_secilen_satir_id = 0;
                cmb_Ders.SelectedIndex = 0;
                txt_Soru.Text = "";
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void Soru_Listesi_Load(object sender, EventArgs e)
        {
            try
            {
                using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                {
                    cmb_Ders.ValueMember = "Ders_ID";
                    cmb_Ders.DisplayMember = "Ders_Adi";
                    cmb_Ders.DataSource = context.Derslers.Where(x => x.Aktiflik_Durumu == true).ToList();
                }

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

        private void Soru_Listesi_FormClosing(object sender, FormClosingEventArgs e)
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
                Soru_Islem frm_soru_islem = new Soru_Islem();
                frm_soru_islem.ShowDialog();
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
                    degisken.get_set_secilen_satir_id = Convert.ToInt32((grd_Liste.CurrentRow.Cells[1].Value));
                    degisken.get_set_yapilacak_islem = "guncelle_sil";
                    Soru_Islem frm_soru_islem = new Soru_Islem();
                    frm_soru_islem.ShowDialog();
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
                                var sorgu = context.Sorus.Single(x => x.Soru_ID == degisken.get_set_secilen_satir_id);
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
            finally {  }
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
            finally {  }
        }

        private void btn_Yazdir_Click(object sender, EventArgs e)
        {
            try
            {
                Analizler frm = new Analizler();
                degisken.get_set_yapilacak_islem = "yazdir_Soru_Rapor";
                frm.ShowDialog();
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void grd_Liste_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                degisken.get_set_secilen_satir_id = Convert.ToInt32((grd_Liste.CurrentRow.Cells[1].Value));
                if (degisken.get_set_yapilacak_islem == "listele")
                {
                    degisken.get_set_yapilacak_islem = "guncelle_sil";
                    Soru_Islem frm_soru_islem = new Soru_Islem();
                    frm_soru_islem.ShowDialog();
                    listele();
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void grd_Liste_Sorted(object sender, EventArgs e)
        {
            grid_islem.satir_numarasi(grd_Liste);
        }

        private void cmb_Ders_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Ders.SelectedIndex != -1)
                {
                    using (DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext())
                    {
                        //var sorgu = from p in context.Konus
                        //            where p.Ders_ID == Convert.ToInt16(cmb_Ders.SelectedValue)
                        //            select p;
                        cmb_Konu.ValueMember = "Konu_ID";
                        cmb_Konu.DisplayMember = "Konu_Adi";
                        cmb_Konu.DataSource = context.Konus.Where(x => x.Aktiflik_Durumu == true && x.Ders_ID == Convert.ToInt16(cmb_Ders.SelectedValue)).ToList();
                    }
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void chk_Ders_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk_Ders.Checked) { cmb_Ders.Enabled = true; cmb_Ders.Focus(); }
                else cmb_Ders.Enabled = false;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void chk_Konu_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk_Konu.Checked) { cmb_Konu.Enabled = true; cmb_Konu.Focus(); }
                else cmb_Konu.Enabled = false;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void chk_Soru_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk_Soru.Checked) { txt_Soru.Enabled = true; txt_Soru.Focus(); }
                else txt_Soru.Enabled = false;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void chk_Aktiflik_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk_Aktiflik.Checked) { chk_Aktiflik.Enabled = true; chk_Aktiflik.Focus(); }
                else chk_Aktiflik.Enabled = false;
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
            finally {  }
        }
    }
}
