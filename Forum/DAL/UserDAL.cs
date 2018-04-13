using Forum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Forum.DAL
{
    public class UserDAL : DbContext
    {
        public DbSet<User> userDB { get; set; }
        public UserDAL() : base("ForumDB") { }
    }
}