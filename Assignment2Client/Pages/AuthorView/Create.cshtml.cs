using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects;
using AutoMapper;
using BusinessObjects.DTO;
using Repositories;

namespace Assignment2Client.Pages.AuthorView
{
    public class CreateModel : PageModel
    {
        private readonly EBookStoreContext _context;
        public IAuthorRepository Repository = new AuthorRepository();
        private IMapper Mapper { get; set; }
        public CreateModel(EBookStoreContext context, IMapper mapper)
        {
            _context = context;
            this.Mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Author Author { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(IFormCollection collection)
        {
            //if (!ModelState.IsValid || _context.Authors == null || Author == null)
            //{
            //    return Page();
            //}

            AuthorDTO dto = new AuthorDTO
            {
                FirstName = collection["FirstName"],
                LastName = collection["LastName"],
                EmailAddress = collection["EmailAddress"],
                Phone = collection["Phone"],
                Address = collection["Address"],
                City = collection["City"],
                State = collection["State"],
                Zip = collection["Zip"]
            };

            var entity = Mapper.Map<Author>(dto);
            Repository.SaveAuthor(entity);

            return RedirectToPage("./Index");
        }
    }
}
