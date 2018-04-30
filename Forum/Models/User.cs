using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using Forum.Properties;

namespace Forum.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        public bool isAdmin { get; set; } = false;

        [Display(Name = "User")]
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(20, ErrorMessage = "Name cannot be longer than 20 characters.")]
        public string username { get; set; }

        private string _pass;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Passord is required.")]
        [DataType(DataType.Password)]
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

        public string AboutMe { get; set; }

        public DateTime? JoinedDate { get; set; }

        public User() { }
        public User(string name, string word, string aboutMe)
        {
            username = name;
            pass = word;
            AboutMe = aboutMe;
            JoinedDate = DateTime.Now;
        }
    }
}