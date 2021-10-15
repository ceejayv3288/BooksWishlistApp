using BooksWishlistApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BooksWishlistApp.Interfaces.Commands
{
    public class SearchBooksCommand : ICommand
    {
        private readonly NewBookPageViewModel _newBookPageViewModel;
        public SearchBooksCommand(NewBookPageViewModel newBookPageViewModel)
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
            if(parameter != null)
            {
                if(parameter is String query)
                    _newBookPageViewModel.GetSearchResults(query);
            }
        }
    }
}
