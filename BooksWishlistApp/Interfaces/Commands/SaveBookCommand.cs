using BooksWishlistApp.Models;
using BooksWishlistApp.ViewModels;
using System;
using System.Windows.Input;

namespace BooksWishlistApp.Interfaces.Commands
{
    public class SaveBookCommand : ICommand
    {
        private readonly NewBookPageViewModel _newBookPageViewModel;
        public SaveBookCommand(NewBookPageViewModel newBookPageViewModel)
        {
            _newBookPageViewModel = newBookPageViewModel;
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
                    _newBookPageViewModel.ExecuteSaveBooksCommand(book);
                }
            }
        }
    }
}
