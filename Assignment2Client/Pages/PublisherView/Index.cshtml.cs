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

namespace Assignment2Client.Pages.PublisherView
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = null;
        private string ApiUrl = "";

        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7276/api/Publisher";
        }

        public IList<Publisher> Publisher { get; set; } = default!;
        public string searchtext = "";

        public async Task OnGetAsync()
        {
            HttpResponseMessage respone = await client.GetAsync(ApiUrl);
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Publisher = (IList<Publisher>)JsonSerializer.Deserialize<List<Publisher>>(strData, options);
        }

        public async Task OnPostAsync()
        {
            string searchText = Request.Form["search"];
            string query = @$"?$filter=contains(PublisherName,'{searchText}')";
            HttpResponseMessage respone = await client.GetAsync(ApiUrl + query);
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Publisher = (IList<Publisher>)JsonSerializer.Deserialize<List<Publisher>>(strData, options);
        }
    }
}
