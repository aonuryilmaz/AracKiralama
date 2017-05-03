using AracKiralama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralama.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Models.ArackiralamaEntities db = new Models.ArackiralamaEntities(); 
        public ActionResult Index()
        {            
            return View(db.Arac.ToList());
        }
        public ActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Form(Arac arac)
        {
            arac.Durum = true;
            db.Arac.Add(arac);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            Arac arc = db.Arac.FirstOrDefault(x => x.Id == id);
            return View(arc);
        }
        [HttpPost]
        public ActionResult Edit(Arac arac)
        {
            Arac aracold = db.Arac.FirstOrDefault(x => x.Id == arac.Id);
            arac.Durum = aracold.Durum;
            db.Entry(aracold).CurrentValues.SetValues(arac);
            db.SaveChanges();      
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int Id)
        {
            Arac arac=db.Arac.FirstOrDefault(x => x.Id == Id);
            db.Arac.Remove(arac);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Status(int Id)
        {
            Arac arac = db.Arac.FirstOrDefault(x => x.Id == Id);
            arac.Durum = !arac.Durum;
            db.SaveChanges();
            return Json(arac.Durum);
        }
    }
}