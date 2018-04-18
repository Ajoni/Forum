using Forum.DAL;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.BL
{
    public class DiscussionBL
    {
        public List<Discussion> GetDiscussions()
        {
            ForumContext db = new ForumContext();
            return db.discussionDB.ToList();
        }

        public void AddDiscussion(Discussion u)
        {
            u.Posted = DateTime.Now;
            ForumContext db = new ForumContext();
            db.discussionDB.Add(u);
            db.SaveChanges();
        }

        public void DeleteDiscussion(Discussion u)
        {
            ForumContext db = new ForumContext();
            db.discussionDB.Remove(u);
            db.SaveChanges();
        }

        public void EditDiscussion(Discussion u)
        {
            ForumContext db = new ForumContext();
            db.Entry(db.discussionDB.SingleOrDefault(x => x.DiscussionId == u.DiscussionId)).CurrentValues.SetValues(u);
            db.SaveChanges();
        }
    }
}