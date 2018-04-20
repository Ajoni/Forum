using Forum.DAL;
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
        [Required(ErrorMessage = "Text is required.")]
        [StringLength(500, ErrorMessage = "Post cannot be longer than 500 characters.")]
        public string Text { get; set; }
        [Display (Name = "OP" )]        
        public DateTime? Posted { get; set; }
        [Key]
        public int id { get; set; }

        [Display(Name ="Discussion")]
        public int DiscussionId { get; set; }
        [Key]
        [ForeignKey("DiscussionId")]
        public virtual Discussion Discussions { get; set; }

        public int PosterId { get; set; }
        [Key]
        [ForeignKey("PosterId")]
        public virtual User user { get; set; }

        public Post() { }
        public Post(string text, int poster)
        {
            Text = text;
            PosterId = poster;
            Posted = DateTime.Now;
        }

        public User GetPoster(int id)
        {
            return new ForumContext().userDB.Where(x => x.id == id).ToList().Single();
        }
    }
}