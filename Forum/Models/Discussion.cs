using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Discussion
    {
        [Key]
        public int DiscussionId { get; set; }
        public DateTime? Posted { get; set; }        
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public string PosterName { get; set; }

        public Discussion() { PosterName = HttpContext.Current.User.Identity.Name; }
        public Discussion(string title, string text)
        {
            Title = title;
            Text = text;
            Posted = DateTime.Now;
        }
    }
}