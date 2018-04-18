using Forum.BL;
using Forum.DAL;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.VM
{
    public class DiscussionDetailsVM
    {
        public Discussion discussion { get; set; }
        public List<Post> posts { get; set; }
      
        public DiscussionDetailsVM()
        {
            
        }
        public DiscussionDetailsVM (Discussion d)
        {
            discussion = d;
            posts = new PostBL().GetPosts();
            posts.Where(x => x.DiscussionId == d.DiscussionId);
            posts.OrderBy(x => x.Posted);
        }

    }
}