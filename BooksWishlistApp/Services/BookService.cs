using BooksWishlistApp.Models;
using BooksWishlistApp.Services;
using BooksWishlistApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Essentials;

//[assembly: Dependency(typeof(BookService))]
namespace BooksWishlistApp.Services
{
    public class BookService : IBookService
    {
        SQLiteAsyncConnection db;
        async Task Init()
        {
            if (db != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Book>();
        }

        public async Task<int> AddBook(Book bookToAdd)
        {
            await Init();
            var id = await db.InsertAsync(bookToAdd);
            return id;
        }

        public async Task<int> DeleteBook(int bookId)
        {
            await Init();
            var id = await db.DeleteAsync<Book>(bookId);
            return id;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            await Init();
            var books = await db.Table<Book>().ToListAsync();
            return books;
        }

        public async Task<Book> GetBook(int bookId)
        {
            await Init();
            var book = await db.Table<Book>()
                .FirstOrDefaultAsync(c => c.id == bookId);
            return book;
        }

        public async Task<List<Book>> GetAllBooksUsingBook(Book book)
        {
            await Init();
            var books = await db.Table<Book>().Where(bookStored => bookStored.authors == book.authors && bookStored.thumbnail == book.thumbnail && bookStored.title == book.title).ToListAsync();
            return books;
        }
    }
}
