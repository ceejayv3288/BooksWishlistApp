using BooksWishlistApp.Models;
using BooksWishlistApp.ViewModels;
using System;
using System.Windows.Input;

namespace BooksWishlistApp.Interfaces.Commands
{
    public class DropOverCommand : ICommand
    {
        private readonly BooksPageViewModel _booksPageViewModel;
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
            _booksPageViewModel.ExecuteDragOverDeleteCommand();
        }
    }
}
