using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotAuthorized()
        {
            Response.StatusCode = 403;
            return View();
        }
    }
}