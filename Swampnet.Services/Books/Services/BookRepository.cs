using Swampnet.Services.Books.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swampnet.Services.Books.Entities;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Swampnet.Services.Books.Services
{
    // http://isbndb.com/api/v2/json/{api-key}/book/{query}
    // Just acting as a reverse proxy to isbndb for now
    // In the future we'll cache this stuff / hit other providers
    public class BookRepository : IBookRepository
    {
        private readonly string _apiKey;

        public BookRepository(IConfiguration configuration)
        {
            _apiKey = configuration["isbndb:api-key"];
        }

        public async Task<BookDetails> GetAsync(string id)
        {
            var endpoint = $"http://isbndb.com/api/v2/json/{_apiKey}/book/{id}";

            using (var client = new HttpClient())
            {
                var rs = await client.GetAsync(endpoint);

                rs.EnsureSuccessStatusCode();

                var json = await rs.Content.ReadAsStringAsync();
                var searchResult = JsonConvert.DeserializeObject<IsbndbBooksResponse>(json);

                return searchResult.data.Select(Convert.ToBookDetails).SingleOrDefault();
            }
        }
    }
}
