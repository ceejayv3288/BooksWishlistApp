using BooksWishlistApp.Interfaces.Commands;
using BooksWishlistApp.Interfaces.Commands.Navigation;
using BooksWishlistApp.Models;
using BooksWishlistApp.Services.Interfaces;
using BooksWishlistApp.Views;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace BooksWishlistApp.ViewModels
{
    public class BooksPageViewModel
    {
        IBookService bookService;

        public NewBookNavigationCommand NewBookNavigationCommand { get; set; }
        public BooksPageAppearingCommand PageAppearingCommand { get; set; }
        public BookSelectedCommand BookSelectedCommand { get; set; }
        public DragStartingCommand DragStartingCommand { get; set; }
        public DropOverCommand DropOverCommand { get; set; }
        public ObservableCollection<Book> SavedBooks { get; set; }

        public BooksPageViewModel()
        {
            NewBookNavigationCommand = new NewBookNavigationCommand(this);
            PageAppearingCommand = new BooksPageAppearingCommand(this);
            BookSelectedCommand = new BookSelectedCommand(this);
            DragStartingCommand = new DragStartingCommand(this);
            DropOverCommand = new DropOverCommand(this);
            SavedBooks = new ObservableCollection<Book>();

            bookService = DependencyService.Get<IBookService>();

            ReadSavedBook();
        }

        private async void ReadSavedBook()
        {
            var books = await bookService.GetAllBooks();

            SavedBooks.Clear();
            foreach (var book in books)
            {
                SavedBooks.Add(book);
            }
        }

        public void ExecuteNewBookCommand()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewBookPage());
        }

        public void ExecutePageAppearingCommand()
        {
            ReadSavedBook();
        }

        public async void ExecuteBookSelectedCommand(Book selectedBook)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new BookDetailsPage(selectedBook));
        }

        //public ICommand DragStartingCommand => new Command<Book>((param) =>
        //{
        //    _dragBook = param;
        //});

        //public ICommand DropOverCommand => new Command(() =>
        //{
        //    if (SavedBooks.Contains(_dragBook))
        //    {
        //        SavedBooks.Remove(_dragBook);
        //        App.Connection.CreateTable<Book>();
        //        int bookDeleted = App.Connection.Delete(_dragBook);
        //        if (bookDeleted == 0)
        //        {
        //            App.Current.MainPage.DisplayAlert("Failed!", "An error has occured.", "Ok");
        //        }
        //    } 
        //});
        public Book _dragBook;

        public async void ExecuteDragOverDeleteCommand()
        {
            if (SavedBooks.Contains(_dragBook))
            {
                SavedBooks.Remove(_dragBook);
                int bookDeleted = await bookService.DeleteBook(_dragBook.id);
                if (bookDeleted == 0)
                {
                    await App.Current.MainPage.DisplayAlert("Failed!", "An error has occured.", "Ok");
                }
            }
        }
    }
}
