using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Authorize]
    public class AnasayfaController : Controller
    {
        veritabani3Entities model = new veritabani3Entities();
        // GET: Anasayfa

     
        public ActionResult Index()
        {
           

            return View();
        }



    }
}