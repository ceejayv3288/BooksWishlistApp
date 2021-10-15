using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static BooksWishlistApp.Models.GoogleBooksAPI;

namespace BooksWishlistApp.Services.Interfaces
{
    public interface IGoogleBooksAPIServices
    {
        Task<BooksAPI> GetSearchListAsync(string query);
    }
}
