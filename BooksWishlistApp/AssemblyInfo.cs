using BooksWishlistApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
[assembly: Dependency(typeof(BookService))]
[assembly: Dependency(typeof(GoogleBooksAPIService))]