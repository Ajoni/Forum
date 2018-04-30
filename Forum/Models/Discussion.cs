using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required(ErrorMessage = "Text is required.")]
        [StringLength(500, ErrorMessage = "Post cannot be longer than 500 characters.")]
        public string Text { get; set; }
        public int PosterId { get; set; }
        [Key]
        [ForeignKey("PosterId")]
        [Display(Name = "Poster")]
        public virtual User user { get; set; }

        public Discussion() {  }
        public Discussion(string title, string text)
        {
            Title = title;
            Text = text;
            Posted = DateTime.Now;
        }
    }
}