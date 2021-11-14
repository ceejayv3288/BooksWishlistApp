using BooksWishlistApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BooksWishlistApp.Services.Interfaces
{
    public interface IBookService
    {
        Task<int> AddBook(Book bookToAdd);
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBook(int bookId);
        Task<int> DeleteBook(int bookId);
        Task<List<Book>> GetAllBooksUsingBook(Book book);
    }
}
