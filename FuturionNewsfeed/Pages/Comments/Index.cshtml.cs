using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FuturionNewsfeed.Data;
using FuturionNewsfeed.Models;

namespace FuturionNewsfeed.Pages.Comments
{
    public class IndexModel : PageModel
    {
        private readonly FuturionNewsfeed.Data.ApplicationDbContext _context;

        public IndexModel(FuturionNewsfeed.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Comment> Comment { get;set; }

        public async Task OnGetAsync()
        {
            Comment = await _context.Comment.ToListAsync();
        }
    }
}
