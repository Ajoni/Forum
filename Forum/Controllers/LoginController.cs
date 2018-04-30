using Forum.BL;
using Forum.DAL;
using Forum.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Forum.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(LoginVM loginVM, string ReturnUrl)
        {
            LoginBL loginBL = new LoginBL();
            if (loginBL.isValidUser(loginVM))
            {             
                FormsAuthentication.SetAuthCookie(loginVM.username, false);
                if(ReturnUrl == null) return RedirectToAction("Index", "Discussion");
                return Redirect(ReturnUrl);
            }

            ModelState.AddModelError("CreditentialError", "Creditential Error");
            return View("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Discussion");
        }

    }

}
