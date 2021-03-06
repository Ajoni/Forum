﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Forum.BL;
using Forum.DAL;
using Forum.Authorize;
using Forum.Models;

namespace Forum.Controllers
{
    public class PostController : Controller
    {
        private ForumContext db = new ForumContext();

        [AdminAuthorize(Users = "admin")]
        public ActionResult Index()
        {
            var postDB = db.postDB.Include(p => p.Discussions).Include(p => p.user);
            return View(postDB.ToList());
        }

        // GET: Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.postDB.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Post/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.DiscussionId = new SelectList(db.discussionDB, "DiscussionId", "Title");
            ViewBag.PosterId = new SelectList(db.userDB, "id", "username");
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Text,Posted,DiscussionId,PosterId")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.DiscussionId =  (int)Session["dId"];
                    var posterID = new ForumContext().userDB
                    .Where(x => x.username == HttpContext.User.Identity.Name)
                    .Select(a => new { a.id})
                    .ToList().Single();                    
                post.PosterId = posterID.id;
                new PostBL().AddPost(post);
                return RedirectToAction("Details", "Discussion", new { id = (int)Session["dId"] });
            }

            ViewBag.DiscussionId = new SelectList(db.discussionDB, "DiscussionId", "Title", post.DiscussionId);
            ViewBag.PosterId = new SelectList(db.userDB, "id", "username", post.PosterId);
            return View(post);
        }

        // GET: Post/Edit/5
        [AdminAuthorize(Users = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.postDB.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            ViewBag.DiscussionId = new SelectList(db.discussionDB, "DiscussionId", "Title", post.DiscussionId);
            ViewBag.PosterId = new SelectList(db.userDB, "id", "username", post.PosterId);
            return View(post);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Text,Posted,DiscussionId,PosterId")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Discussion");
            }
            ViewBag.DiscussionId = new SelectList(db.discussionDB, "DiscussionId", "Title", post.DiscussionId);
            ViewBag.PosterId = new SelectList(db.userDB, "id", "username", post.PosterId);
            return View(post);
        }

        // GET: Post/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.postDB.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            if (Helper.Helper.checkPermission(post.PosterId))
            {
                return View(post);
            }
            else
                return RedirectToAction("NotAuthorized", "Error");
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.postDB.Find(id);
            db.postDB.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Details", "Discussion", new { id = (int)Session["dId"] });
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
