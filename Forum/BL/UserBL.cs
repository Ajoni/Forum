using Forum.DAL;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.BL
{
    public class UserBL
    {
        public List<User> GetUsers()
        {
            UserDAL db = new UserDAL();
            return db.userDB.ToList();
        }

        public void AddUser(User u)
        {
            UserDAL db = new UserDAL();
            db.userDB.Add(u);
            db.SaveChanges();
        }

        public void DeleteUser(User u)
        {
            UserDAL db = new UserDAL();
            db.userDB.Remove(u);
            db.SaveChanges();
        }

        public void EditUser(User u)
        {
            UserDAL db = new UserDAL();
            db.Entry(db.userDB.SingleOrDefault(x => x.id == u.id)).CurrentValues.SetValues(u);
            db.SaveChanges();
        }
    }
}