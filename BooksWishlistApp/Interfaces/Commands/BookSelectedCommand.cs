using BooksWishlistApp.Models;
using BooksWishlistApp.ViewModels;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace BooksWishlistApp.Interfaces.Commands
{
    public class BookSelectedCommand : ICommand
    {
        private readonly BooksPageViewModel _booksPageViewModel;
        public BookSelectedCommand(BooksPageViewModel booksPageViewModel)
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
            if (parameter != null)
            {
                if (parameter is ListView bookList)
                    _booksPageViewModel.BookSelectedAction(bookList.SelectedItem as Book);
                else if (parameter is Book book)
                    _booksPageViewModel.BookSelectedAction(book);
            }        
        }
    }
}
