using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FuturionNewsfeed.Models;

namespace FuturionNewsfeed.Pages.News
{
    public class IndexModel : PageModel
    {
        private readonly FuturionNewsfeed.Models.FuturionNewsfeedContext _context;

        public IndexModel(FuturionNewsfeed.Models.FuturionNewsfeedContext context)
        {
            _context = context;
        }

        public IList<NewsItem> NewsItem { get;set; }

        public async Task OnGetAsync()
        {
            _context.NewsItem.Include(x => x.Comments).Load();
            NewsItem = await _context.NewsItem.ToListAsync();
        }
    }
}
