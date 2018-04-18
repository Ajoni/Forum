using Forum.DAL;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.BL
{
    public class PostBL
    {
        public List<Post> GetPosts()
        {
            ForumContext db = new ForumContext();
            return db.postDB.ToList();
        }

        public void AddPost(Post u)
        {
            u.Posted = DateTime.Now;
            ForumContext db = new ForumContext();
            db.postDB.Add(u);
            db.SaveChanges();
        }

        public void DeletePost(Post u)
        {
            ForumContext db = new ForumContext();
            db.postDB.Remove(u);
            db.SaveChanges();
        }

        public void EditPost(Post u)
        {
            ForumContext db = new ForumContext();
            db.Entry(db.postDB.SingleOrDefault(x => x.id == u.id)).CurrentValues.SetValues(u);
            db.SaveChanges();
        }
    }
}