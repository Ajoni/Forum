using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Post
    {
        public string Text { get; set; }
        [Display (Name = "OP" )]
        public int PosterId { get; set; }
        public DateTime Posted { get; private set; }
        [Key]
        public int id { get; set; }
        [Key]
        [ForeignKey("Discussion")]
        public int DiscNum { get; private set; }

        private Post() { }
        public Post(string text, int poster, int n)
        {
            Text = text;
            PosterId = poster;
            Posted = DateTime.Now;
            DiscNum = n;
        }
    }
}