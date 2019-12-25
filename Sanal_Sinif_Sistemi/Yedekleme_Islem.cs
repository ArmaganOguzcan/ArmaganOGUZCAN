using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace Sanal_Sinif_Sistemi
{
    public partial class Yedekleme_Islem : Form
    {
        public Yedekleme_Islem()
        {
            InitializeComponent();
        }

        Degiskenler degisken = new Degiskenler();

        private void Yedekleme_Islem_Load(object sender, EventArgs e)
        {

        }

        private void Yedekleme_Islem_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                degisken.get_set_yapilacak_islem = "listele";
                degisken.get_set_secilen_satir_id = 0;
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { Memory.FlushMemory(); }
        }

        private void btn_Yedekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Yedek_Adi.Text != "" && txt_Yedek_Yeri.Text != "")
                {
                    DialogResult secenek = MessageBox.Show("Yedek Alınsın Mı?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secenek == DialogResult.Yes)
                    {
                        string tarih = DateTime.Now.ToString("dd/MM/yyyy").ToString();
                        string hedef = @txt_Yedek_Yeri.Text + "\\" + txt_Yedek_Adi.Text + "-" + tarih + ".bak";

                        prg_Yukleniyor.Value = 0;
                        Server dbServer = new Server(new ServerConnection("."));
                        Backup dbBackup = new Backup()
                        {
                            Action = BackupActionType.Database,
                            Database = "StokTakip",
                        };
                        dbServer.KillAllProcesses(dbBackup.Database);
                        dbBackup.Devices.AddDevice(hedef, DeviceType.File);
                        dbBackup.Initialize = true;
                        dbBackup.PercentComplete += dbBackup_PercentComplete;
                        dbBackup.Complete += dbBackup_Complete;
                        dbBackup.SqlBackupAsync(dbServer);
                    }
                    else if (secenek == DialogResult.No)
                    {
                        //Hayır seçeneğine tıklandığında çalıştırılacak kodlar
                    }
                }
                else MessageBox.Show("Gerekli Alanları Doldurunz!");
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void btn_Geri_Yukle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Yedek_Adi.Text != "" && txt_Yedek_Yeri.Text != "")
                {
                    Anasayfa frm = new Anasayfa();

                    DialogResult secenek = MessageBox.Show("Yedekten Geri Yükleme Yapılsın mı?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secenek == DialogResult.Yes)
                    {
                        string hedef = @txt_Yedek_Yeri.Text + "\\" + txt_Yedek_Adi.Text;

                        prg_Yukleniyor.Value = 0;
                        Server dbServer = new Server(new ServerConnection("."));
                        Restore dbRestore = new Restore()
                        {
                            Database = "StokTakip",
                            Action = RestoreActionType.Database,
                            ReplaceDatabase = true,
                            NoRecovery = false,
                        };
                        dbServer.KillAllProcesses(dbRestore.Database);
                        dbRestore.Devices.AddDevice(hedef, DeviceType.File);
                        dbRestore.PercentComplete += dbRestore_PercentComplete;
                        dbRestore.Complete += dbRestore_Complete;
                        dbRestore.SqlRestoreAsync(dbServer);

                        //Uygulamaya yeniden giriş yapılır
                        this.Visible = false;
                        frm.ShowDialog();
                    }
                    else if (secenek == DialogResult.No)
                    {
                        //Hayır seçeneğine tıklandığında çalıştırılacak kodlar
                    }
                }
                else MessageBox.Show("Gerekli Alanları Doldurunz!");
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { }
        }

        private void btn_Ara_Click(object sender, EventArgs e)
        {
            try
            {
                if (rd_Yedekle.Checked == true)
                {
                    FolderBrowserDialog dosya = new FolderBrowserDialog();
                    dosya.Description = "Lütfen aşağıdaki listeden bir dizin seçiniz.";
                    dosya.RootFolder = Environment.SpecialFolder.Desktop;
                    dosya.SelectedPath = @"C:\ydk\";
                    if (dosya.ShowDialog() == DialogResult.OK)
                    {
                        txt_Yedek_Yeri.Text = dosya.SelectedPath;
                    }
                }
                else if (rd_Geri_Yukle.Checked == true)
                {
                    //string hedef = Application.StartupPath + @"\ydk\" + txt_Yedek_Adi.Text + ".bak";
                    OpenFileDialog dosya = new OpenFileDialog();
                    dosya.Reset();
                    dosya.InitialDirectory = @"C:\ydk\";
                    dosya.RestoreDirectory = true;
                    dosya.CheckFileExists = false;
                    dosya.Title = "SQL Dosyası Seçiniz..";
                    //dosya.FilterIndex = 2;
                    //dosya.Multiselect = true;  
                    dosya.Filter = "MS_SQL Dosyası |*.bak";

                    if (dosya.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo bilgi = new FileInfo(dosya.FileName);
                        txt_Yedek_Adi.Text = bilgi.Name;
                        txt_Yedek_Yeri.Text = bilgi.DirectoryName;
                    }
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        void dbBackup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            try
            {
                prg_Yukleniyor.Invoke((MethodInvoker)delegate
                {
                    prg_Yukleniyor.Value = e.Percent;
                    prg_Yukleniyor.Update();
                });
                lbl_prg_Yukleniyor.Invoke((MethodInvoker)delegate
                {
                    lbl_prg_Yukleniyor.Text = e.Percent.ToString() + "%";
                });
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        void dbRestore_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            try
            {
                prg_Yukleniyor.Invoke((MethodInvoker)delegate
                {
                    prg_Yukleniyor.Value = e.Percent;
                    prg_Yukleniyor.Update();
                });
                lbl_prg_Yukleniyor.Invoke((MethodInvoker)delegate
                {
                    lbl_prg_Yukleniyor.Text = e.Percent.ToString() + "%";
                });
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        void dbBackup_Complete(object sender, ServerMessageEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    lbl_Durum.Invoke((MethodInvoker)delegate
                    {
                        lbl_Durum.Text = e.Error.Message;
                    });
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        void dbRestore_Complete(object sender, ServerMessageEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    lbl_Durum.Invoke((MethodInvoker)delegate
                    {
                        lbl_Durum.Text = e.Error.Message;
                    });
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void rd_Yedekle_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rd_Yedekle.Checked == true)
                {
                    rd_Geri_Yukle.Checked = false;
                    txt_Yedek_Adi.Enabled = true;
                    btn_Yedekle.Enabled = true;
                    btn_Geri_Yukle.Enabled = false;
                    txt_Yedek_Yeri.Text = "";
                    txt_Yedek_Adi.Text = "";
                    lbl_prg_Yukleniyor.Text = "";
                    prg_Yukleniyor.Value = 0;
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }

        private void rd_Geri_Yukle_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rd_Geri_Yukle.Checked == true)
                {
                    rd_Yedekle.Checked = false;
                    txt_Yedek_Adi.Enabled = false;
                    btn_Yedekle.Enabled = false;
                    btn_Geri_Yukle.Enabled = true;
                    txt_Yedek_Yeri.Text = "";
                    txt_Yedek_Adi.Text = "";
                    lbl_Durum.Text = "";
                    txt_Yedek_Adi.Text = "";
                    lbl_prg_Yukleniyor.Text = "";
                    prg_Yukleniyor.Value = 0;
                }
            }
            catch (Exception hata) { MessageBox.Show("Hata Oluştu!", hata.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {  }
        }
    }
}
