using AracKiralama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralama.Controllers
{
    public class KiralamaController : Controller
    {
        // GET: Kiralama
        Models.ArackiralamaEntities db = new Models.ArackiralamaEntities();
       
        public ActionResult Index(int Id)
        {
            Arac arc = db.Arac.FirstOrDefault(x => x.Id == Id);
            return View(arc);
        }
        public ActionResult Add(int Id,DateTime startdate, DateTime enddate)
        {            
            string email = Session["Email"].ToString();
            Musteri mstri = db.Musteri.FirstOrDefault(x => x.Email == email);
            Arac arc = db.Arac.FirstOrDefault(x => x.Id == Id);
            arc.Durum = false;
            db.Entry(arc).CurrentValues.SetValues(arc);
            Kiralama kiralama = new Kiralama();
            kiralama.AracId = arc.Id;
            kiralama.MüsteriTc = mstri.TC;
            kiralama.Baslangıc = startdate;
            kiralama.Bitis = enddate;           
            db.Kiralama.Add(kiralama);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}