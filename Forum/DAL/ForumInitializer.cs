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
            var userDB = new List<User>
            {
                new User{ isAdmin =true,username="admin",pass="admin", id=1},
                new User{ isAdmin =false,username="Quick",pass="Quick", id=2},
                new User{ isAdmin =false,username="Human",pass="Human", id=3},
                new User{ isAdmin =false,username="Person",pass="Person", id=4},
            };
            userDB.ForEach(x => context.userDB.Add(x));
            context.SaveChanges();
            var discussionDB = new List<Discussion>
            {
                new Discussion{Title = "First",Text="My post is here!",Posted=DateTime.Parse("2005-09-01"),PosterId=1}
            };
            discussionDB.ForEach(x => context.discussionDB.Add(x));
            context.SaveChanges();
        }
    }
}