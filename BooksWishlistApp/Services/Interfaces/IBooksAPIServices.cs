﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static BooksWishlistApp.Models.GoogleBooksAPI;

namespace BooksWishlistApp.Services.Interfaces
{
    public interface IBooksAPIServices
    {
        Task<BooksAPI> GetSearchListAsync(string query);
    }
}
