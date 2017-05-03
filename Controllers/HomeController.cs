using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models;

namespace AracKiralama.Controllers
{
    public class HomeController : Controller
    {
        Models.ArackiralamaEntities db = new Models.ArackiralamaEntities();
        // GET: Home
        public ActionResult Index()
        {
            List<Arac> aracs = db.Arac.Where(x=>x.Durum==true).ToList();
           return View(aracs);
        }
    }
}