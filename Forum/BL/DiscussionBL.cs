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
            DiscussionDAL db = new DiscussionDAL();
            return db.discussionDB.ToList();
        }

        public void AddDiscussion(Discussion u)
        {
            DiscussionDAL db = new DiscussionDAL();
            db.discussionDB.Add(u);
            db.SaveChanges();
        }

        public void DeleteDiscussion(Discussion u)
        {
            DiscussionDAL db = new DiscussionDAL();
            db.discussionDB.Remove(u);
            db.SaveChanges();
        }

        public void EditDiscussion(Discussion u)
        {
            DiscussionDAL db = new DiscussionDAL();
            db.Entry(db.discussionDB.SingleOrDefault(x => x.id == u.id)).CurrentValues.SetValues(u);
            db.SaveChanges();
        }
    }
}