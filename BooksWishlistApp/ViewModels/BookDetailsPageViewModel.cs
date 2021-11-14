using BooksWishlistApp.Interfaces.Commands;
using BooksWishlistApp.Models;
using BooksWishlistApp.Services.Interfaces;
using Xamarin.Forms;

namespace BooksWishlistApp.ViewModels
{
    public class BookDetailsPageViewModel : BaseViewModel
    {
        public DeleteBookCommand DeleteBookCommand { get; set; }

        IBookService bookService;

        public Book SelectedBook { get; set; }
        private string title { get; set; }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        private string author { get; set; }
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }
        private string thumbnail { get; set; }
        public string Thumbnail
        {
            get { return thumbnail; }
            set
            {
                thumbnail = value;
                OnPropertyChanged("Thumbnail");
            }
        }

        public BookDetailsPageViewModel()
        {
            DeleteBookCommand = new DeleteBookCommand(this);

            bookService = DependencyService.Get<IBookService>();
        }

        public BookDetailsPageViewModel(Book selectedBook)
        {
            DeleteBookCommand = new DeleteBookCommand(this);

            bookService = DependencyService.Get<IBookService>();

            Thumbnail = selectedBook.thumbnail;
            Author = selectedBook.authors;
            Title = selectedBook.title;

            this.SelectedBook = selectedBook;
        }

        public async void DeleteBook()
        {
            int bookDeleted = await bookService.DeleteBook(SelectedBook.id);
            if (bookDeleted >= 1)
            {
                await App.Current.MainPage.DisplayAlert("Success!", "The book is successfully deleted.", "Ok");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
                await App.Current.MainPage.DisplayAlert("Failed!", "An error has occured.", "Ok");
        }
    }
}
