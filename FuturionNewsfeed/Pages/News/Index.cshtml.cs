using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FuturionNewsfeed.Data;
using FuturionNewsfeed.Models;

namespace FuturionNewsfeed.Pages.News
{
    public class IndexModel : PageModel
    {
        private readonly FuturionNewsfeed.Data.ApplicationDbContext _context;

        public IndexModel(FuturionNewsfeed.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<NewsItem> NewsItem { get;set; }

        public async Task OnGetAsync()
        {
            NewsItem = await _context.NewsItem.ToListAsync();
        }
    }
}
