using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class SiparisController : Controller
    {
        private veritabani3Entities db = new veritabani3Entities();

        public ActionResult Index()
        {
         
            var siparisler = db.Siparisler.ToList();
            return View(siparisler);
        }


        [HttpPost]
        public ActionResult SiparisVer()
        {
            // Kullanıcının sepetini sipariş olarak onaylamak için gerekli işlemleri yapın
            var sepetIcerik = db.UrunSepet.ToList();

            // Sipariş tablosuna dönüştürme işlemleri
            decimal toplamTutar = 0;
            foreach (var item in sepetIcerik)
            {
                toplamTutar += item.Urunler.Fiyat * item.Adet;
            }

            Siparisler yeniSiparis = new Siparisler
            {
                SepetID = (int)Session["SepetId"],
                ToplamTutar = toplamTutar
            };
            db.Siparisler.Add(yeniSiparis);
            db.SaveChanges();

            // Siparişi verdikten sonra sepeti temizleyin
            foreach (var item in sepetIcerik)
            {
                db.UrunSepet.Remove(item);
            }
            db.SaveChanges();

            return RedirectToAction("SiparisOde");
        }



        public ActionResult SiparisOde()
        {

            
            return View();
        }





    }
}