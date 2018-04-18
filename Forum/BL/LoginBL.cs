using Forum.DAL;
using Forum.Models;
using Forum.Properties;
using Forum.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Forum.BL
{
    public class LoginBL
    {
        public LoginBL() { }
        public bool isValidUser(LoginVM loginVM)
        {
            byte[] salt = System.Text.Encoding.UTF8.GetBytes(Resource1.salt);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(loginVM.pass);
            string hash;
            using (var hmac = new HMACSHA256(salt))
            {
                hash = Convert.ToBase64String(hmac.ComputeHash(data));
            }
            ForumContext db = new ForumContext();
            List<User> logins = db.userDB.ToList();

            foreach (User login in logins)
            {
                if (login.username == loginVM.username && login.pass == hash)
                {
                    return true;
                }
            }

            return false;
        }
    }
}