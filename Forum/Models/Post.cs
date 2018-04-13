﻿using System;
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
        public User Poster { get; set; }
        public DateTime Posted { get; private set; }
        [Key]
        public int PostNum { get; private set; }
        [Key]
        [ForeignKey("Discussion")]
        public int DiscNum { get; private set; }

        private Post() { }
        public Post(string text, User u, int n)
        {
            Text = text;
            Poster = u;
            Posted = DateTime.Now;
            PostNum = n;
        }
    }
}