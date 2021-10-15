using BooksWishlistApp.ViewModels;
using System;
using System.Windows.Input;

namespace BooksWishlistApp.Interfaces.Commands
{
    public class BooksPageAppearingCommand : ICommand
    {
        private readonly BooksPageViewModel _booksPageViewModel;
        public BooksPageAppearingCommand(BooksPageViewModel booksPageViewModel)
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
            _booksPageViewModel.PageAppearingAction();
        }
    }
}
