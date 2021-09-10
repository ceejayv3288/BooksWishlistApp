using BooksWishlistApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static BooksWishlistApp.Models.GoogleBooksAPI;

namespace BooksWishlistApp.Interfaces.Commands
{
    public class BookSelectedCommand : ICommand
    {
        BooksPageViewModel _booksPageViewModel;
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
            //var selectedBook = (parameter as ListView).SelectedItem as Book;
            //_booksPageViewModel.BookSelectedAction(selectedBook);
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
