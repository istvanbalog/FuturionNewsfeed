using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FuturionNewsfeed.Models;

namespace FuturionNewsfeed.Pages.News
{
    public class CreateModel : PageModel
    {
        private readonly FuturionNewsfeed.Models.FuturionNewsfeedContext _context;

        public CreateModel(FuturionNewsfeed.Models.FuturionNewsfeedContext context)
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

            NewsItem.CreationDateTime = DateTime.Now;
            NewsItem.CreatorUsername = User.Identity.Name;

            _context.NewsItem.Add(NewsItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}