using BooksWishlistApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksWishlistApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BooksPage : ContentPage
    {
        BooksPageViewModel _booksPageViewModel;
        public BooksPage()
        {
            _booksPageViewModel = new BooksPageViewModel();
            BindingContext = _booksPageViewModel;
            InitializeComponent();
        }
    }
}