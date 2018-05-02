using Forum.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Helper
{
    public static class Helper
    {
        public static bool uniqueUsername(string name)
        {
            ForumContext db = new ForumContext();
            var r = db.userDB.Where(d => d.username == name).ToList();
            if (r.Count == 0)
            {
                return true;
            }
            else return false;
        }
        //checks if current logged in user has permisson (owns it or is admin) to requested action/object
        public static bool checkPermission(int id)
        {
            ForumContext db = new ForumContext();
            string name = HttpContext.Current.User.Identity.Name; System.Web.HttpContext.Current.User.Identity.GetUserId();
            var r = db.userDB.Where(d => d.username == name).ToList().First(); //guaranteed to be unique -> one record returned
            if(r.id == id || r.isAdmin)
            {
                return true;
            }
            return false;
        }
    }
}