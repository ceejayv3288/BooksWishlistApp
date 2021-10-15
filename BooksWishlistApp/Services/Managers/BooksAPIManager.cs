using BooksWishlistApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static BooksWishlistApp.Models.GoogleBooksAPI;

namespace BooksWishlistApp.Services.Managers
{
    public class BooksAPIManager
    {
        private readonly IBooksAPIServices GoogleBooksAPIServices;

        public BooksAPIManager(IBooksAPIServices googleBooksAPIServices)
        {
            GoogleBooksAPIServices = googleBooksAPIServices;
        }

        public Task<BooksAPI> GetSearchListAsync(string query)
        {
            return GoogleBooksAPIServices.GetSearchListAsync(query);
        }
    }
}
