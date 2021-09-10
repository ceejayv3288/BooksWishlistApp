using BooksWishlistApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static BooksWishlistApp.Models.GoogleBooksAPI;

namespace BooksWishlistApp.Services.Managers
{
    public class GoogleBooksAPIManager
    {
        IGoogleBooksAPIServices GoogleBooksAPIServices;

        public GoogleBooksAPIManager(IGoogleBooksAPIServices googleBooksAPIServices)
        {
            GoogleBooksAPIServices = googleBooksAPIServices;
        }

        public Task<BooksAPI> GetSearchListAsync(string query)
        {
            return GoogleBooksAPIServices.GetSearchListAsync(query);
        }
    }
}
