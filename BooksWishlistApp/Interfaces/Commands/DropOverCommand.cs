using BooksWishlistApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using static BooksWishlistApp.Models.GoogleBooksApi;

namespace BooksWishlistApp.Interfaces.Commands
{
    public class DropOverCommand : ICommand
    {
        BooksPageViewModel _booksPageViewModel;
        public DropOverCommand(BooksPageViewModel booksPageViewModel)
        {
            _booksPageViewModel = booksPageViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_booksPageViewModel.SavedBooks.Contains(_booksPageViewModel._dragBook))
            {
                _booksPageViewModel.SavedBooks.Remove(_booksPageViewModel._dragBook);
                App.Connection.CreateTable<Book>();
                int bookDeleted = App.Connection.Delete(_booksPageViewModel._dragBook);
                if (bookDeleted == 0)
                {
                    App.Current.MainPage.DisplayAlert("Failed!", "An error has occured.", "Ok");
                }
            }
        }
    }
}
