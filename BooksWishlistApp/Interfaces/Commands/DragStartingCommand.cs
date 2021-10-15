using BooksWishlistApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using static BooksWishlistApp.Models.GoogleBooksApi;

namespace BooksWishlistApp.Interfaces.Commands
{
    public class DragStartingCommand : ICommand
    {
        BooksPageViewModel _booksPageViewModel;
        public DragStartingCommand(BooksPageViewModel booksPageViewModel)
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
                if (parameter is Book book)
                {
                    _booksPageViewModel._dragBook = book;
                }
            }
        }
    }
}
