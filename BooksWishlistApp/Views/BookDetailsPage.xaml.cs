using BooksWishlistApp.Models;
using BooksWishlistApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksWishlistApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookDetailsPage : ContentPage
    {
        private readonly BookDetailsPageViewModel _bookDetailsPageViewModel;

        public BookDetailsPage()
        {
            _bookDetailsPageViewModel = new BookDetailsPageViewModel();
            BindingContext = _bookDetailsPageViewModel;
            InitializeComponent();
        }

        public BookDetailsPage(Book selectedBook)
        {
            _bookDetailsPageViewModel = new BookDetailsPageViewModel(selectedBook);
            BindingContext = _bookDetailsPageViewModel;
            InitializeComponent();
        }
    }
}