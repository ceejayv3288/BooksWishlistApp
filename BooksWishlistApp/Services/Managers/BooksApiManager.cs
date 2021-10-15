using BooksWishlistApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static BooksWishlistApp.Models.GoogleBooksApi;

namespace BooksWishlistApp.Services.Managers
{
    public class BooksApiManager
    {
        IBooksApiServices BooksApiServices;

        public BooksApiManager(IBooksApiServices iBooksApiServices)
        {
            BooksApiServices = iBooksApiServices;
        }

        public Task<BooksApi> GetSearchListAsync(string query)
        {
            return BooksApiServices.GetSearchListAsync(query);
        }
    }
}
