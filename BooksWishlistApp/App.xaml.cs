using BooksWishlistApp.Services;
using BooksWishlistApp.Services.Interfaces;
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
        public static BooksAPIManager BooksAPIManager { get; private set; }
        public static JsonSerializer JsonSerializer { get; private set; }
        //public static string DatabasePath { get; set; }
        //public static SQLiteConnection Connection { get; private set; }

        public App(string databasePath)
        {
            InitializeComponent();

            //Alternative dependency injection aside form declaring directly in the Service or in the AssemblyInfo.cs file as Assembly
            //DependencyService.Register<IBookService, BookService>();
            //DependencyService.Register<IBooksAPIService, GoogleBooksAPIService>();

            //Getting the database path of both Android and iOS code
            //DatabasePath = databasePath;
            //Connection = new SQLiteConnection(DatabasePath);

            //Singleton API services sample
            //BooksAPIManager = new BooksAPIManager(new GoogleBooksAPIService());

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
