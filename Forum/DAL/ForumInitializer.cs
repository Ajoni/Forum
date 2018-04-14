using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.DAL
{
    public class ForumInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ForumContext>
    {
        protected override void Seed(ForumContext context)
        {
            var discussionDB = new List<Discussion>
            {
                new Discussion{Title = "oi",Text="asdas",Posted=DateTime.Parse("2005-09-01")}
            };
            discussionDB.ForEach(x => context.discussionDB.Add(x));
            context.SaveChanges();
        }
    }
}