using Forum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Forum.DAL
{
    public class DiscussionDAL : DbContext
    {
        public DbSet<Discussion> userDB { get; set; }
        public DiscussionDAL() : base("ForumDB") { }
    }