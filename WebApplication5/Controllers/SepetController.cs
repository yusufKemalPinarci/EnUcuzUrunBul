using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class SepetController : Controller
    {
        veritabani3Entities model=new veritabani3Entities();
       
        // GET: Sepet
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SepettenCikar(int id)
        {
            UrunSepet sepetIcerik = model.UrunSepet.FirstOrDefault(x => x.UrunID == id);

            // Önce adet sayısını alalım
            int adet = sepetIcerik.Adet;

            // Ürünü Sepet'ten çıkartalım
            model.UrunSepet.Remove(sepetIcerik);
            model.SaveChanges();

            // Ürünün stok miktarını bulalım
            Urunler urun = model.Urunler.FirstOrDefault(x => x.UrunID == id);
            if (urun != null)
            {
                // Stok miktarını arttıralım
                urun.StokMiktari += adet;
                model.SaveChanges();
            }

            int sepetID = sepetIcerik.SepetID;
            return RedirectToAction("SepetGetir", new { id = sepetID });
        }






        public ActionResult SepetGetir(int id)
        {
            List<UrunSepet> s = model.UrunSepet.Where(x => x.SepetID == id).ToList();

            

            // Sipariş tablosuna dönüştürme işlemleri
            decimal toplamTutar = 0;
            foreach (var item in s)
            {
                toplamTutar += item.Urunler.Fiyat * item.Adet;
            }
            ViewBag.ToplamTutar = toplamTutar;

            // List<Urunler> u = model.Urunler.Where(x => x.UrunID == s.UrunID).ToList();
            return View(s);
        }
        [HttpPost]
        public ActionResult SiparisVer(int id)
        {
            List<Sepet> s = model.Sepet.Where(x => x.KullaniciID == id).ToList();

            // List<Urunler> u = model.Urunler.Where(x => x.UrunID == s.UrunID).ToList();
            return View(s);
        }

    }
}