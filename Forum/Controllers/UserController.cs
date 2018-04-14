using Forum.BL;
using Forum.DAL;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User u)
        {
            UserBL userBL = new UserBL();
            userBL.AddUser(u);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int id)
        {
            List<User> users = new UserBL().GetUsers();
            return View(users.Find(x => x.id == id));
        }
        [HttpPost]
        public ActionResult Delete(User u)
        {
            new UserBL().DeleteUser(u);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            List<User> users = new UserBL().GetUsers();
            return View(users.Find(x => x.id == id));
        }
        [HttpPost]
        public ActionResult Edit(User u)
        {
            new UserBL().EditUser(u);
            return RedirectToAction("Index", "Home");
        }

    }
}