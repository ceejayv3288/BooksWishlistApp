using BooksWishlistApp.Services.Interfaces;
using System.Threading.Tasks;
using static BooksWishlistApp.Models.GoogleBooksAPI;

namespace BooksWishlistApp.Services.Managers
{
    public class BooksAPIManager
    {
        private readonly IGoogleBooksAPIService GoogleBooksAPIServices;

        public BooksAPIManager(IGoogleBooksAPIService googleBooksAPIServices)
        {
            GoogleBooksAPIServices = googleBooksAPIServices;
        }

        public Task<BooksAPI> GetSearchListAsync(string query)
        {
            return GoogleBooksAPIServices.GetSearchListAsync(query);
        }
    }
}
