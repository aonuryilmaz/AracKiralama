using AracKiralama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralama.Controllers
{
    public class MusteriController : Controller
    {
        Models.ArackiralamaEntities db = new Models.ArackiralamaEntities();
        // GET: Musteri
        public ActionResult Index()
        {
            ViewBag.total = 0;
            string email = Session["Email"].ToString();
            Musteri mstri = db.Musteri.FirstOrDefault(x => x.Email == email);
            var krlma = db.Kiralama.Where(x => x.MüsteriTc == mstri.TC).ToList();
            List<Arac> kiralananlar = new List<Arac>();
            int aracId = 0;
            int total = 0;
            foreach (var item in krlma)
            {
                if (aracId != Convert.ToInt32(item.AracId)){
                    Arac arc = db.Arac.FirstOrDefault(x => x.Id == item.AracId);
                    if (arc.Durum == false) kiralananlar.Add(arc);
                    aracId = Convert.ToInt32(item.AracId);
                    total += Convert.ToInt32(arc.Fiyat);
                }
             
            }
            ViewBag.total = total;
            return View(kiralananlar);
        }
        public ActionResult Kayıt()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayıt(Musteri mstri)
        {
            db.Musteri.Add(mstri);
            db.SaveChanges();
            return RedirectToAction("Giris");
        }
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(Login user)
        {
            string mail =user.email;
            string pswdx = user.password;
            Musteri musteri = db.Musteri.FirstOrDefault(x => x.Email == mail);
            if (musteri.password != pswdx)
            {
                ViewBag.error = "Hatalı Giriş";
                return View();
            }else
            {
                Session["Email"] = musteri.Email;
                Session["UserName"] = musteri.AdSoyad;
                return RedirectToAction("Index", "Home");
            }
            
        }
        public ActionResult Cıkıs()
        {
            Session.Remove("Email");
            Session.Remove("UserName");
            return RedirectToAction("Index", "Home");
        }

    }
}