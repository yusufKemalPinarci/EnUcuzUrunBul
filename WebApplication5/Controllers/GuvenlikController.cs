using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication5.Models;
namespace WebApplication5.Controllers
{


      
    [Authorize]
    public class GuvenlikController : Controller
    {
        veritabani3Entities model=new veritabani3Entities();

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult SignUp()
        {
          

            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult SignUp(Kullanici k)
        {
            if (ModelState.IsValid)
            {
                try {
                    veritabani3Entities db = new veritabani3Entities();
                    db.Kullanici.Add(k);
                    Sepet sepet = new Sepet { KullaniciID = k.KullaniciID };
                    db.Sepet.Add(sepet);
                    db.SaveChanges();

                }
                catch (DbEntityValidationException e) { 
                    Console.WriteLine("benim mesajım" +e.Message);
                
                }

                
                //List<Kullanici> list=model.Kullanici.ToList();

                }

                return RedirectToAction("Login", "Guvenlik");   
        }



        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Kullanici k)
        {
            Kullanici u = model.Kullanici.FirstOrDefault(x => x.KullaniciAdi == k.KullaniciAdi && x.Sifre == k.Sifre);
            
            
            if (u == null)
            {
                ViewBag.hata = "Kullanıcı Adı veya Kullanıcı Şifre Hatalı!";
                return View();
            }
            else
            {
                Session["KullaniciID"] = u.KullaniciID;
                Sepet s=model.Sepet.FirstOrDefault(x=>x.KullaniciID==u.KullaniciID);
                Session["SepetId"] = s.SepetID;
                FormsAuthentication.SetAuthCookie(u.KullaniciAdi, false);
                return RedirectToAction("Index", "AnaSayfa");
            }
        }

        [Authorize]
        public ActionResult LogOut()
        {
            //string cookiname = FormsAuthentication.FormsCookieName;
            //string ad = HttpContext.User.Identity.Name;
            //HttpCookie atc = HttpContext.Request.Cookies[cookiname];
            //FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(atc.Value);
            //string isim = ticket.Name;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Hata()
        {
            return View();
        }
    }
}