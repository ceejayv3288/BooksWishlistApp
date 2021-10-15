using BooksWishlistApp.Models;
using BooksWishlistApp.ViewModels;
using System;
using System.Windows.Input;

namespace BooksWishlistApp.Interfaces.Commands
{
    public class DragStartingCommand : ICommand
    {
        private readonly BooksPageViewModel _booksPageViewModel;
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
