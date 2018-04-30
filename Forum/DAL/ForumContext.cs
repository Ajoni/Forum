using Forum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Forum.DAL
{
    public class ForumContext : DbContext
    {
        public ForumContext() : base("ForumDB") { }

        public DbSet<Post> postDB { get; set; }
        public DbSet<User> userDB { get; set; }
        public DbSet<Discussion> discussionDB { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}