using BooksWishlistApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BooksWishlistApp.Interfaces.Commands.Navigation
{
    public class NewBookNavigationCommand : ICommand
    {
        BooksPageViewModel _booksPageViewModel;
        public NewBookNavigationCommand(BooksPageViewModel booksPageViewModel)
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
            _booksPageViewModel.NewBookAction();
        }
    }
}
