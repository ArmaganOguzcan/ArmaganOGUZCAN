using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sanal_Sinif_Sistemi;
using System.Linq;

namespace Sinav_Test
{
    [TestClass]
    public class Testler
    {
        [TestMethod]
        public void Kullanici_Giris()
        {
            Kullanici_Giris _login = new Kullanici_Giris();
            Assert.IsTrue(_login.kullanici_dogrula("Sevket321", "D123"));
        }

        [TestMethod]
        public void Kullanici_Giris_Bos()
        {
            try
            {
                Kullanici_Giris _login = new Kullanici_Giris();
                _login.kullanici_dogrula(null,"D123");
            }
            catch (Exception hata)
            {
                Assert.Fail("Hata Oluştu");
                StringAssert.Contains(hata.Message, "Boş Veri");
                return;
            }
            
        }

        [TestMethod]
        public void Ders_Listesi()
        {
            DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext();
            var sorgu = context.Derslers.OrderBy(x => x.Ders_Adi).Select(x => new
            {
                x.Ders_ID,
                x.Ders_Adi,
                x.Aktiflik_Durumu
            });

            Assert.IsNotNull(sorgu);
        }

        [TestMethod]
        public void Ders_Ekle()
        {
            DataClasses_Sanal_SinifDataContext context = new DataClasses_Sanal_SinifDataContext();
            Dersler _ders = new Dersler
            {
                Ders_Adi = null,
                Aktiflik_Durumu = true,
                Aciklama = ""
            };
            try
            {
                context.Derslers.InsertOnSubmit(_ders);
                context.SubmitChanges();
            }
            catch (Exception hata)
            {
                StringAssert.Contains(hata.Message, "Boş Veri");
                Assert.Fail("Hata Oluştu");
                return;
            }
            
        }

        [TestMethod]
        public void Isaretli_Cevap()
        {
            Soru_Islem _soru_islem = new Soru_Islem();

            Int16 sonuc = _soru_islem.dogrucevap(false, false, true, false);

            Assert.AreEqual(sonuc, 3);
        }

        
    }
}