using BooksWishlistApp.Interfaces.Commands;
using BooksWishlistApp.Models;
using BooksWishlistApp.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace BooksWishlistApp.ViewModels
{
    public class NewBookPageViewModel
    {
        public SaveBookCommand SaveBookCommand { get; set; }
        public SearchBooksCommand SearchBooksCommand { get; set; }
        public ObservableCollection<Book> SearchResults { get; set; }

        IBookService bookService;
        IGoogleBooksAPIService googleBooksAPIService;

        public NewBookPageViewModel()
        {
            SaveBookCommand = new SaveBookCommand(this);
            SearchBooksCommand = new SearchBooksCommand(this);
            SearchResults = new ObservableCollection<Book>();

            bookService = DependencyService.Get<IBookService>();
            googleBooksAPIService = DependencyService.Get<IGoogleBooksAPIService>();
        }

        public async void ExecuteSearchBooksCommand(string query)
        {
            try
            {
                var data = await googleBooksAPIService.GetSearchListAsync(query);

                SearchResults.Clear();
                foreach (var book in data.items)
                {
                    Book currentBook = new Book
                    {
                        thumbnail = (book.volumeInfo.imageLinks?.thumbnail) ?? string.Empty,
                        title = (book.volumeInfo?.title) ?? string.Empty
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
                throw ex;
            }
        }

        public async void ExecuteSaveBooksCommand(Book book)
        {
            var record = await bookService.GetAllBooksUsingBook(book);
            if (record.Count == 0)
            {
                int bookInserted = await bookService.AddBook(book);
                if (bookInserted >= 1)
                    await App.Current.MainPage.DisplayAlert("Success!", "Book saved", "Ok");
                else
                    await App.Current.MainPage.DisplayAlert("Failure", "An error occured while saving the book", "Ok");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Failed", "Book already saved!", "Ok");
            }
        }
    }
}
