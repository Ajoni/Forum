using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Forum.Authorize;
using Forum.BL;
using Forum.DAL;
using Forum.Models;
using Forum.VM;

namespace Forum.Controllers
{
    public class DiscussionController : Controller
    {
        private ForumContext db = new ForumContext();

        // GET: Discussion
        public ActionResult Index()
        {
            return View(db.discussionDB.ToList());
        }

        // GET: Discussion/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discussion discussion = db.discussionDB.Find(id);
            if (discussion == null)
            {
                return HttpNotFound();
            }
            Session["dId"] = id;
            return View(new DiscussionDetailsVM(discussion));
        }

        // GET: Discussion/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Discussion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiscussionId,Posted,Title,Text")] Discussion discussion)
        {
            if (ModelState.IsValid)
            {
                new DiscussionBL().AddDiscussion(discussion);
                return RedirectToAction("Index", "Discussion");
            }

            return View(discussion);
        }

        // GET: Discussion/Edit/5
        [AdminAuthorize(Users = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discussion discussion = db.discussionDB.Find(id);
            if (discussion == null)
            {
                return HttpNotFound();
            }
            return View(discussion);
        }

        // POST: Discussion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiscussionId,Posted,Title,Text")] Discussion discussion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discussion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Discussion");
            }
            return View(discussion);
        }

        // GET: Discussion/Delete/5
        [AdminAuthorize(Users = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discussion discussion = db.discussionDB.Find(id);
            if (discussion == null)
            {
                return HttpNotFound();
            }
            return View(discussion);
        }

        // POST: Discussion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Discussion discussion = db.discussionDB.Find(id);
            db.discussionDB.Remove(discussion);
            db.SaveChanges();
            return RedirectToAction("Index", "Discussion");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
