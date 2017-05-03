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
        // GET: Home
        public ActionResult Index()
        {          
           return View();
        }
    }
}