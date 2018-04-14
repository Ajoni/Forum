using Forum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Forum.DAL
{
    public class PostDAL : DbContext
    {
        public DbSet<Post> postDB { get; set; }
        public PostDAL() : base("ForumDB") { }
    }
}