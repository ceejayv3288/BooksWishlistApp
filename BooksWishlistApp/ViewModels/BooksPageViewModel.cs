using BooksWishlistApp.Interfaces.Commands.Navigation;
using BooksWishlistApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BooksWishlistApp.ViewModels
{
    public class BooksPageViewModel
    {
        public NewBookNavigationCommand NewBookNavigationCommand { get; set; }

        public BooksPageViewModel()
        {
            NewBookNavigationCommand = new NewBookNavigationCommand(this);
        }

        public void NewBookAction()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewBookPage());
        }
    }
}
