using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Assignment2Client.Pages.AuthorView
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = null;
        private string BaseUrl = "";

        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BaseUrl = "https://localhost:7276/api/Author";
        }

        public IList<BusinessObjects.Author> Author { get; set; } = default!;
        public string searchtext = "";

        public async Task OnGetAsync()
        {
            HttpResponseMessage respone = await client.GetAsync(BaseUrl);
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Author = (IList<BusinessObjects.Author>)JsonSerializer.Deserialize<List<BusinessObjects.Author>>(strData, options);
        }

        public async Task OnPostAsync()
        {
            string searchText = Request.Form["search"];
            string query = @$"?$filter=contains(FirstName,'{searchText}') or contains(LastName,'{searchText}')";
            HttpResponseMessage respone = await client.GetAsync(BaseUrl + query);
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Author = (IList<BusinessObjects.Author>)JsonSerializer.Deserialize<List<BusinessObjects.Author>>(strData, options);
        }
    }
}
