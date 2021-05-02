using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane2.Models.Entity;

namespace MvcKutuphane2.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLPERSONEL.ToList();//kategoriyi listeleme işlemi
            return View(degerler);
        }

        [HttpGet]//Sayfa yüklendiğinde aşağıdaki çalışsın
        public ActionResult PersonelEkle() //bir şey yapmadan sadece sayfayı geri yükle
        {
            return View();
        }

        [HttpPost] //sayfaya veri gönderme işlemi gerçekleşince burası çalışsın
        public ActionResult PersonelEkle(TBLPERSONEL p) //p yi kategoriyi eklerken göndereceğimiz değer
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.TBLPERSONEL.Add(p);
            db.SaveChanges();
            return View();//sayfayı geri döndürüyor
        }
        public ActionResult PersonelSil(int id)
        {
            var person = db.TBLPERSONEL.Find(id);  //tblKategoride bul id den gönderdiğim değeri(sil butonu ile gönderiyorum)
            db.TBLPERSONEL.Remove(person); //Bulunan değeri kategori tablosundan sil
            db.SaveChanges();  //Değişiklikleri kaydet
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var prs = db.TBLPERSONEL.Find(id);  // id ye göre değerimizi bulup kr-tg ye at
            return View("PersonelGetir", prs);  //bana kategoriGetir sayfasını ktg değeri ile döndür
        }

        public ActionResult PersonelGuncelle(TBLPERSONEL p)
        {
            var prs = db.TBLPERSONEL.Find(p.ID);
            prs.PERSONEL = p.PERSONEL; // diğer taraftan guncelle komutu ile gelen adı ktg ya-e attık
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}