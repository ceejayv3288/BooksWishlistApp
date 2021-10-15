using BooksWishlistApp.Helpers;
using BooksWishlistApp.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static BooksWishlistApp.Models.GoogleBooksApi;

namespace BooksWishlistApp.Services
{
    public class GoogleBooksApiServices : IBooksApiServices
    {
        readonly HttpClient client = new HttpClient();

        public GoogleBooksApiServices()
        {
            //client.BaseAddress = new Uri("uri here");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<BooksApi> GetSearchListAsync(string query)
        {
            try
            {
                //var result = await Client.GetStringAsync($"https://www.googleapis.com/books/v1/volumes?q={query}&key={Constants.GOOGLE_BOOKS_API_KEY}");
                //return JsonConvert.DeserializeObject<BooksApi>(books);

                BooksApi books = new BooksApi();
                HttpResponseMessage response = await client.GetAsync($"https://www.googleapis.com/books/v1/volumes?q={query}&key={Constants.GOOGLE_BOOKS_API_KEY}");
                if (response.IsSuccessStatusCode)
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            using (var json = new JsonTextReader(reader))
                            {
                                books = App.JsonSerializer.Deserialize<BooksApi>(json);
                            }
                        }
                    }
                }

                return books;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
