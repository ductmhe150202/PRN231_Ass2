using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using System.Net.Http.Headers;

namespace Assigment2Client.Pages.BookView
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObjects.EBookStoreContext _context;

        private readonly HttpClient client = null;
        private string ApiUrl = "";

        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7276/api/Books";
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Books != null)
            {
                Book = await _context.Books
                .Include(b => b.Publisher).ToListAsync();
            }
        }
    }
}
