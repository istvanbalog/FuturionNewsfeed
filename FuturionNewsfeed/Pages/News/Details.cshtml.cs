﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FuturionNewsfeed.Models;

namespace FuturionNewsfeed.Pages.News
{
    public class DetailsModel : PageModel
    {
        private readonly FuturionNewsfeed.Models.FuturionNewsfeedContext _context;

        public DetailsModel(FuturionNewsfeed.Models.FuturionNewsfeedContext context)
        {
            _context = context;
        }

        public NewsItem NewsItem { get; set; }

        [BindProperty]
        public Comment Comment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NewsItem = await _context.NewsItem.SingleOrDefaultAsync(m => m.Id == id);

            if (NewsItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Comment.CreationDateTime = DateTime.Now;
            Comment.CreatorUsername = User.Identity.Name;

            NewsItem = await _context.NewsItem.SingleOrDefaultAsync(m => m.Id == id);

            await _context.Comment.AddAsync(Comment);

            if(NewsItem.Comments == null)
            {
                NewsItem.Comments = new List<Comment>();
            }

            NewsItem.Comments.Add(Comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
