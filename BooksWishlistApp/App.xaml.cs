using BooksWishlistApp.Services;
using BooksWishlistApp.Services.Managers;
using BooksWishlistApp.Views;
using Newtonsoft.Json;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksWishlistApp
{
    public partial class App : Application
    {
        public static SQLiteConnection Connection { get; private set; }
        public static BooksAPIManager BooksAPIManager { get; private set; }
        public static JsonSerializer JsonSerializer { get; private set; }
        public static string DatabasePath { get; set; }

        public App(string databasePath)
        {
            InitializeComponent();

            DatabasePath = databasePath;
            Connection = new SQLiteConnection(DatabasePath);
            BooksAPIManager = new BooksAPIManager(new GoogleBooksAPIServices());
            JsonSerializer = new JsonSerializer();

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
