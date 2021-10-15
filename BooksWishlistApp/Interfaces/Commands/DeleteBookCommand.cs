using BooksWishlistApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BooksWishlistApp.Interfaces.Commands
{
    public class DeleteBookCommand : ICommand
    {
        private readonly BookDetailsPageViewModel _bookDetailsPageViewModel;
        public DeleteBookCommand(BookDetailsPageViewModel bookDetailsPageViewModel)
        {
            _bookDetailsPageViewModel = bookDetailsPageViewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _bookDetailsPageViewModel.DeleteBook();
        }
    }
}
