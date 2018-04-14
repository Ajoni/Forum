using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Discussion");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application should segfault and you with it.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page has segfauletd already and so should you.";

            return View();
        }
    }
}