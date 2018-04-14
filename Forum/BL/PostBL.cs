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
            PostDAL db = new PostDAL();
            return db.postDB.ToList();
        }

        public void AddPost(Post u)
        {
            PostDAL db = new PostDAL();
            db.postDB.Add(u);
            db.SaveChanges();
        }

        public void DeletePost(Post u)
        {
            PostDAL db = new PostDAL();
            db.postDB.Remove(u);
            db.SaveChanges();
        }

        public void EditPost(Post u)
        {
            PostDAL db = new PostDAL();
            db.Entry(db.postDB.SingleOrDefault(x => x.id == u.id)).CurrentValues.SetValues(u);
            db.SaveChanges();
        }
    }
}