using BooksWishlistApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static BooksWishlistApp.Models.GoogleBooksAPI;

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