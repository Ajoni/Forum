using Forum.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Forum.VM
{
    public class LoginVM
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Required.")]
        public string username { get; set; }

        private string _pass;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Required.")]
        public string pass
        {
            get { return _pass; }
            set
            {
                byte[] salt = System.Text.Encoding.UTF8.GetBytes(Resource1.salt);
                byte[] data = System.Text.Encoding.UTF8.GetBytes(value);
                using (var hmac = new HMACSHA256(salt))
                {
                    _pass = Convert.ToBase64String(hmac.ComputeHash(data));
                }
            }
        }
    }
}