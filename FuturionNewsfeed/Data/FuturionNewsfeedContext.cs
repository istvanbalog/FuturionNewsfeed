using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FuturionNewsfeed.Models
{
    public class FuturionNewsfeedContext : DbContext
    {
        public FuturionNewsfeedContext (DbContextOptions<FuturionNewsfeedContext> options)
            : base(options)
        {
        }

        public DbSet<FuturionNewsfeed.Models.NewsItem> NewsItem { get; set; }
        public DbSet<FuturionNewsfeed.Models.Comment> Comment { get; set; }
    }
}
