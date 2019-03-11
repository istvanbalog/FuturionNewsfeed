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
    public class DetailsModel : PageModel
    {
        private readonly FuturionNewsfeed.Data.ApplicationDbContext _context;

        public DetailsModel(FuturionNewsfeed.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Comment Comment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Comment = await _context.Comment.SingleOrDefaultAsync(m => m.Id == id);

            if (Comment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
