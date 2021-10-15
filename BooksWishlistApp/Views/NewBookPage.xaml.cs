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
    public partial class NewBookPage : ContentPage
    {
        private readonly NewBookPageViewModel _newBookPageViewModel;
        public NewBookPage()
        {
            _newBookPageViewModel = new NewBookPageViewModel();
            BindingContext = _newBookPageViewModel;
            InitializeComponent();
        }
    }
}