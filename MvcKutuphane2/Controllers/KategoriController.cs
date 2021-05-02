using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane2.Models.Entity; //Modelime ait tabloları kullanabilmem için kütüphane gibi tanımlamam gerekiyor
using MvcKutuphane2.Controllers;

namespace MvcKutuphane2.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities(); //global nesne modelime ait.Kütüphaneye ait tablolara ve özelliklerine ulaşmamı sağlar

        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORI.Where(x=>x.DURUM==true).ToList();//kategoriyi listeleme işlemi
            return View(degerler); // geriye değerleri döndürür
        }
        
        

        [HttpGet]//Sayfa yüklendiğinde aşağıdaki çalışsın
        public ActionResult KategoriEkle() //bir şey yapmadan sadece sayfayı geri yükle
        {
            return View();
        }

        [HttpPost] //sayfaya veri gönderme işlemi gerçekleşince burası çalışsın
        public ActionResult KategoriEkle(TBLKATEGORI p) //p yi kategoriyi eklerken göndereceğimiz değer
        {
            db.TBLKATEGORI.Add(p);
            db.SaveChanges();
            return View();//sayfayı geri döndürüyor
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKATEGORI.Find(id);  //tblKategoride bul id den gönderdiğim değeri(sil butonu ile gönderiyorum)
            //db.TBLKATEGORI.Remove(kategori); //Bulunan değeri kategori tablosundan sil
            kategori.DURUM = false; 
            db.SaveChanges();  //Değişiklikleri kaydet
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBLKATEGORI.Find(id);  // id ye göre değerimizi bulup kr-tg ye at
            return View("KategoriGetir", ktg);  //bana kategoriGetir sayfasını ktg değeri ile döndür
        }

        public ActionResult KategoriGuncelle(TBLKATEGORI p)
        {
            var ktg = db.TBLKATEGORI.Find(p.ID);
            ktg.AD = p.AD; // diğer taraftan guncelle komutu ile gelen adı ktg ya-e attık
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}