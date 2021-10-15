using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static BooksWishlistApp.Models.GoogleBooksApi;

namespace BooksWishlistApp.Services.Interfaces
{
    public interface IBooksApiServices
    {
        Task<BooksApi> GetSearchListAsync(string query);
    }
}
