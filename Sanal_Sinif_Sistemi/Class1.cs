using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sanal_Sinif_Sistemi
{
    
    class Memory
    {
        [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]

        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);

        public static void FlushMemory()
        {
            GC.Collect();

            GC.WaitForPendingFinalizers();

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
    }

    class Degiskenler
    {
        private static string yapilacak_islem = "";
        private static string yapilacak_filtre = "";
        private static int secilen_satir_id = 0;
        private static int kullanici_id = 0;
        private static int yetki_id = 0;
        private static string kul_adi_soyadi = "";
        private static object rapor_sorgu;
        private static int son_test_id = 0;
       
        public string get_set_yapilacak_islem
        {
            set { yapilacak_islem = value; }
            get { return yapilacak_islem; }
        }
        public string get_set_yapilacak_filtre
        {
            set { yapilacak_filtre = value; }
            get { return yapilacak_filtre; }
        }
        public int get_set_secilen_satir_id
        {
            set { secilen_satir_id = value; }
            get { return secilen_satir_id; }
        }
        public int get_set_kullanici_id
        {
            set { kullanici_id = value; }
            get { return kullanici_id; }
        }
        public int get_set_yetki_id
        {
            set { yetki_id = value; }
            get { return yetki_id; }
        }
        public string get_set_kul_adi_soyadi
        {
            set { kul_adi_soyadi = value; }
            get { return kul_adi_soyadi; }
        }
        public object get_set_rapor_sorgu
        {
            set { rapor_sorgu = value; }
            get { return rapor_sorgu; }
        }
        public int get_set_son_test_id
        {
            set { son_test_id = value; }
            get { return son_test_id; }
        }
    }

    class Grid_Islemler
    {
        /*private DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        private DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        private DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
        */

        public void satir_numarasi(DataGridView dataGridView)
        {
            try
            {
                if (dataGridView != null)
                {
                    for (int count = 0; (count < (dataGridView.Rows.Count)); count++)
                    {
                        dataGridView.Rows[count].HeaderCell.Value = string.Format((count + 1).ToString(), "0");
                    }
                }
            }
            catch { MessageBox.Show("Hata Oluştu!"); }
            finally { }
        }

        public void grid_arka_renk(DataGridView datagridview)
        {
            try
            {
                for (int i = 0; i < datagridview.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        datagridview.Rows[i].DefaultCellStyle.BackColor = Color.Snow;
                        datagridview.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        datagridview.Rows[i].DefaultCellStyle.BackColor = Color.MistyRose;
                        datagridview.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
            catch { MessageBox.Show("Hata Oluştu!"); }
            finally { }
        }

        public void nesne_genislik(Form frm, DataGridView grd, GroupBox grp_box, Panel pnl)
        {
            try
            {
                int grd_genislik = 0;
                int grd_liste_genislik = 0;
                int pnl_islem_genislik = 0;
                int grp_liste_genislik = 0;
                int frm_genislik = 0;

                for (int i = 0; i < grd.ColumnCount; i++)
                {
                    if (grd.Columns[i].Visible == true) grd_genislik += grd.Columns[i].Width;
                }

                grd_liste_genislik = grd_genislik + 100;
                pnl_islem_genislik = (grd_liste_genislik);
                grp_liste_genislik = (grd.Location.X + grd_liste_genislik + 10);
                frm_genislik = grp_box.Location.X + grp_liste_genislik + 40;

                if (frm_genislik < 1340)
                {
                    grd.Width = grd_liste_genislik;
                    pnl.Width = pnl_islem_genislik;
                    grp_box.Width = grp_liste_genislik;
                    frm.Width = frm_genislik;
                }
            }
            catch { MessageBox.Show("Hata Oluştu!"); }
            finally { Memory.FlushMemory(); }
        }


        /*public void grid_stil(DataGridViewColumn column, string stil)
        {
            if (stil == "stil1")
            {
                //Ortalama
                dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle = dataGridViewCellStyle1;
            }
            else if (stil == "stil2")
            {
                //2 Basamak
                //dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                dataGridViewCellStyle2.Format = "N2";
                column.DefaultCellStyle = dataGridViewCellStyle2;
            }
            if (stil == "stil3")
            {
                //2 Basamak + Para Birimi
                //dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                dataGridViewCellStyle3.Format = "C2";
                column.DefaultCellStyle = dataGridViewCellStyle3;
            }
        }
        */
    }

    class Textbox_Kontrol
    {
        public void buyukharf(TextBox textbox)
        {
            try
            {
                if (textbox != null)
                {
                    textbox.Text = textbox.Text.ToUpper();
                    textbox.SelectionStart = textbox.Text.Length;
                }
            }
            catch { MessageBox.Show("Hata Oluştu!"); }
            finally { }
        }
    }
}