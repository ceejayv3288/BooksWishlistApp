using BooksWishlistApp.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static BooksWishlistApp.Models.GoogleBooksAPI;

namespace BooksWishlistApp.ViewModels
{
    public class NewBookPageViewModel
    {
        public SearchBooksCommand SearchBooksCommand { get; set; }
        public ObservableCollection<Book> SearchResults { get; set; }

        public NewBookPageViewModel()
        {
            SearchBooksCommand = new SearchBooksCommand(this);
            SearchResults = new ObservableCollection<Book>();
        }

        public async void GetSearchResults(string query)
        {
            try
            {
                var data = await App.GoogleBooksAPIManager.GetSearchListAsync(query);

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
    }
}
