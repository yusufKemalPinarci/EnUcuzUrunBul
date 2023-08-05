using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication5.Models;
using WebApplication5.Security;


namespace WebApplication5.Controllers
{
    public class UrunController : Controller
    {
        veritabani3Entities model = new veritabani3Entities();

        [MyAuthorization(Roles= "A,C,P")]
        // GET: Urun
        [HttpGet]
        public ActionResult Index()
        {
            List<Urunler> u = model.Urunler.ToList();

            return View(u);
        }


        [HttpPost]
        public ActionResult Index2()
        {
            string urunIsmi = Request.Form["UrunAdi"];
            Urunler u = model.Urunler.FirstOrDefault(x => x.UrunAdi == urunIsmi);

            List<Urunler> urunler = model.Urunler.Where(x => x.UrunAdi.Contains(urunIsmi)).OrderBy(x => x.Fiyat).ToList();

            return View(urunler);

        }



        [HttpPost]
        [MyAuthorization(Roles = "A,P")]
        public ActionResult UrunSil(int id)
        {
            Urunler urun = model.Urunler.FirstOrDefault(x => x.UrunID == id);

            if (urun != null)
            {
                model.Urunler.Remove(urun);
                model.SaveChanges();
                return View(urun);
            }

            return null;

        }

        [HttpGet]
        [MyAuthorization(Roles = "A,P")]
        public ActionResult UrunEkle()
        {
            
            List<Kategoriler> kategori = model.Kategoriler.ToList();
            List<Markalar> marka = model.Markalar.ToList();
            Urunler u = new Urunler();
            ViewBag.kategori = kategori;
            ViewBag.marka = marka;
            return View(u);
        }

        [HttpPost]
        [MyAuthorization(Roles = "A,P")]
        public ActionResult UrunEkle(Urunler urun)
        {
            model.Urunler.AddOrUpdate(urun);
            model.SaveChanges();
            return RedirectToAction("UrunListele");
        }

        [HttpGet]
        [MyAuthorization(Roles = "A,P")]
        public ActionResult UrunGuncelle(int id) 
        {
            Urunler urun = model.Urunler.FirstOrDefault(x =>x.UrunID == id);
            List<Kategoriler> kategori = model.Kategoriler.ToList();
            List<Markalar> marka = model.Markalar.ToList();

            ViewBag.kategori = kategori;
            ViewBag.marka = marka;


            return View("UrunEkle", urun);

        }

       
        public ActionResult UrunListele()
        {
            
            List<Urunler> u = model.Urunler.ToList();
            
            return View(u);

        }


      


        [HttpPost]
        [MyAuthorization(Roles = "A,P,C")]
        public ActionResult SepeteEkle(int urunID, int sepetId,int adet)
        {
            UrunSepet existingItem = model.UrunSepet.FirstOrDefault(x => x.UrunID == urunID && x.SepetID == sepetId);

            if (existingItem == null)
            {
                UrunSepet sepetItem = new UrunSepet
                {
                    SepetID = sepetId,
                    UrunID = urunID,
                    Adet = adet
                };
                model.UrunSepet.Add(sepetItem);
            }
            else
            {
                existingItem.Adet+=adet; // Increase the quantity if the item already exists in the cart
            }

            // Decrease the stock quantity
            Urunler urun = model.Urunler.FirstOrDefault(x => x.UrunID == urunID);
            if (urun != null)
            {
                urun.StokMiktari -= adet;
            }

            model.SaveChanges();
            return RedirectToAction("UrunListele", "Urun");
        }



    }
}