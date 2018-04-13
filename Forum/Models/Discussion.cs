using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Discussion
    {
        public List<Post> Posts { get; set; }
        [Key]
        public int num { get; private set; }
    }
}