using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBlogApi.Models;


namespace MyBlogApi.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext (DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }
        public DbSet<BlogPost> BlogPosts => Set<BlogPost>();
    
        
    }
}