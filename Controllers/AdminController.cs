using AracKiralama.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Web.Mvc;
using System.Web;

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
        public ActionResult Form(Arac arac,HttpPostedFileBase _document)
        {
            
            if (_document != null)
            {
               
                string fileName = _document.FileName;
                string path = System.Web.HttpContext.Current.Server.MapPath("/Content/Image/" + fileName);
                _document.SaveAs(path);
                string last= "/Content/Image/" + fileName;
                arac.imagePath = last;
            }
            arac.Durum = true;
            db.Arac.Add(arac);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            Arac arc = db.Arac.FirstOrDefault(x => x.Id == id);
            TempData["image"] = arc.imagePath;
            return View(arc);
        }
        [HttpPost]
        public ActionResult Edit(Arac arac,HttpPostedFileBase _document)
        {
            if (_document != null)
            {
                string fileName = _document.FileName;
                string path = System.Web.HttpContext.Current.Server.MapPath("/Content/Image/" + fileName);
                _document.SaveAs(path);
                string last = "/Content/Image/" + fileName;
                arac.imagePath = last;
            }else
            {
                arac.imagePath = TempData["image"].ToString();
            }
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