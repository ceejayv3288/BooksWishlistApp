using BooksWishlistApp.Interfaces.Commands;
using BooksWishlistApp.Interfaces.Commands.Navigation;
using BooksWishlistApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using static BooksWishlistApp.Models.GoogleBooksAPI;

namespace BooksWishlistApp.ViewModels
{
    public class BooksPageViewModel
    {
        public NewBookNavigationCommand NewBookNavigationCommand { get; set; }
        public BooksPageAppearingCommand PageAppearingCommand { get; set; }
        public BookSelectedCommand BookSelectedCommand { get; set; }
        public ObservableCollection<Book> SavedBooks { get; set; }

        public BooksPageViewModel()
        {
            NewBookNavigationCommand = new NewBookNavigationCommand(this);
            PageAppearingCommand = new BooksPageAppearingCommand(this);
            BookSelectedCommand = new BookSelectedCommand(this);
            SavedBooks = new ObservableCollection<Book>();
            ReadSavedBook();
        }

        private void ReadSavedBook()
        {
            App.Connection.CreateTable<Book>();
            var books = App.Connection.Table<Book>().ToList();

            SavedBooks.Clear();
            foreach (var book in books)
            {
                SavedBooks.Add(book);
            }
        }

        public void NewBookAction()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewBookPage());
        }

        public void PageAppearingAction()
        {
            ReadSavedBook();
        }

        public async void BookSelectedAction(Book selectedBook)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new BookDetailsPage(selectedBook));
        }
    }
}
