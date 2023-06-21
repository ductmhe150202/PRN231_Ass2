using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects;
using Repositories;

namespace Assignment2Client.Pages.BookView
{
    public class CreateModel : PageModel
    {
        private readonly EBookStoreContext _context;
        IBookRepository repository = new BookRepository();
        public CreateModel(EBookStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Publisher"] = new SelectList(_context.Publishers, "PubId", "PublisherName");
            Book = new Book();
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            repository.SaveBook(Book);

            return RedirectToPage("./Index");
        }
    }
}
