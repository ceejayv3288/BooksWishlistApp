using BooksWishlistApp.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static BooksWishlistApp.Models.GoogleBooksApi;

namespace BooksWishlistApp.ViewModels
{
    public class NewBookPageViewModel
    {
        public SaveBookCommand SaveBookCommand { get; set; }
        public SearchBooksCommand SearchBooksCommand { get; set; }
        public ObservableCollection<Book> SearchResults { get; set; }

        public NewBookPageViewModel()
        {
            SaveBookCommand = new SaveBookCommand(this);
            SearchBooksCommand = new SearchBooksCommand(this);
            SearchResults = new ObservableCollection<Book>();
        }

        public async void GetSearchResults(string query)
        {
            try
            {
                var data = await App.BooksApiManager.GetSearchListAsync(query);

                SearchResults.Clear();
                foreach (var book in data.items)
                {
                    Book currentBook = new Book
                    {
                        thumbnail = book.volumeInfo.imageLinks?.thumbnail != null ? book.volumeInfo.imageLinks?.thumbnail : string.Empty,
                        title = book.volumeInfo?.title != null ? book.volumeInfo?.title : string.Empty
                    };

                    string authors = string.Empty;
                    if (book.volumeInfo.authors != null)
                    {
                        foreach (var author in book.volumeInfo.authors)
                        {
                            authors += author + ", ";
                        }
                        authors = authors.Substring(0, authors.Length - 2);
                        currentBook.authors = authors;
                    }

                    SearchResults.Add(currentBook);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void SaveBooks(Book book)
        {
            var recordCount = App.Connection.Table<Book>().Where(bookStored => bookStored.authors == book.authors && bookStored.thumbnail == book.thumbnail && bookStored.title == book.title).Count();
            if (recordCount == 0)
            {
                App.Connection.CreateTable<Book>();
                int bookInserted = App.Connection.Insert(book);
                if (bookInserted >= 1)
                    App.Current.MainPage.DisplayAlert("Success!", "Book saved", "Ok");
                else
                    App.Current.MainPage.DisplayAlert("Failure", "An error occured while saving the book", "Ok");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Failed", "Book already saved!", "Ok");
            }
        }
    }
}
