﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;

namespace Assignment2Client.Pages.AuthorView
{
    public class DeleteModel : PageModel
    {
        private readonly BusinessObjects.EBookStoreContext _context;

        public DeleteModel(BusinessObjects.EBookStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
      public BusinessObjects.Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FirstOrDefaultAsync(m => m.AuthorId == id);

            if (author == null)
            {
                return NotFound();
            }
            else 
            {
                Author = author;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }
            var author = await _context.Authors.FindAsync(id);

            if (author != null)
            {
                Author = author;
                _context.Authors.Remove(Author);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
