using BooksWishlistApp.Helpers;
using BooksWishlistApp.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using static BooksWishlistApp.Models.GoogleBooksAPI;

namespace BooksWishlistApp.Services
{
    public class GoogleBooksAPIService : IBooksAPIService
    {
        readonly HttpClient client = new HttpClient();

        public GoogleBooksAPIService()
        {
            //client.BaseAddress = new Uri("uri here");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<BooksAPI> GetSearchListAsync(string query)
        {
            try
            {
                //var result = await Client.GetStringAsync($"https://www.googleapis.com/books/v1/volumes?q={query}&key={Constants.GOOGLE_BOOKS_API_KEY}");
                //return JsonConvert.DeserializeObject<BooksAPI>(books);

                BooksAPI books = new BooksAPI();
                HttpResponseMessage response = await client.GetAsync($"https://www.googleapis.com/books/v1/volumes?q={query}&key={Constants.GOOGLE_BOOKS_API_KEY}");
                if (response.IsSuccessStatusCode)
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            using (var json = new JsonTextReader(reader))
                            {
                                books = App.JsonSerializer.Deserialize<BooksAPI>(json);
                            }
                        }
                    }
                }

                return books;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
