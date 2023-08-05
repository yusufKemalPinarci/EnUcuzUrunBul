using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class KategoriController : Controller
    {
        veritabani3Entities model = new veritabani3Entities();
        
        // GET: Kategori
        public ActionResult Index()
        {
            List<Kategoriler> k = model.Kategoriler.ToList();

            return View(k);
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
           
            List<Urunler> urunler = model.Urunler.Where(x=>x.KategoriID==id).ToList();
           

            return View(urunler);
        }

        [HttpGet]
        public ActionResult UrunListele(int id)
        {
            ViewBag.KullaniciID = Session["KullaniciID"];
            List<Urunler> urunler = model.Urunler.Where(x => x.KategoriID == id).ToList();


            return View(urunler);
        }

        public void KategoriSil(int id)
        {
            Kategoriler k = model.Kategoriler.FirstOrDefault(x => x.KategoriID == id);
            if (k != null) 
            { 
                model.Kategoriler.Remove(k);
                model.SaveChanges();
            }
        }

    }
}