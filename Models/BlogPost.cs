using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApi.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}