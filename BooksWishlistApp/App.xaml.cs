using BooksWishlistApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksWishlistApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new BooksPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
