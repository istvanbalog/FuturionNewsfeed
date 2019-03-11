using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FuturionNewsfeed.Data;
using FuturionNewsfeed.Models;

namespace FuturionNewsfeed.Pages.News
{
    public class CreateModel : PageModel
    {
        private readonly FuturionNewsfeed.Data.ApplicationDbContext _context;

        public CreateModel(FuturionNewsfeed.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NewsItem NewsItem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.NewsItem.Add(NewsItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}