using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects;

namespace Assigment2Client.Pages.BookView
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObjects.EBookStoreContext _context;

        public CreateModel(BusinessObjects.EBookStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PubId"] = new SelectList(_context.Publishers, "PubId", "City");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Books == null || Book == null)
            {
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
