using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects;
using Repositories;

namespace Assignment2Client.Pages.PublisherView
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObjects.EBookStoreContext _context;
        IPublisherRepository repository = new PublisherRepository();
        public CreateModel(BusinessObjects.EBookStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Publisher = new Publisher();
            return Page();
        }

        [BindProperty]
        public Publisher Publisher { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {    
            repository.SavePublisher(Publisher);

            return RedirectToPage("./Index");
        }
    }
}
