﻿using BooksWishlistApp.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using static BooksWishlistApp.Models.GoogleBooksAPI;

namespace BooksWishlistApp.ViewModels
{
    public class BookDetailsPageViewModel : BaseViewModel
    {
        public DeleteBookCommand DeleteBookCommand { get; set; }

        public Book selectedBook { get; set; }
        public string title { get; set; }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public string author { get; set; }
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }
        public string thumbnail { get; set; }
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
        }

        public BookDetailsPageViewModel(Book selectedBook)
        {
            DeleteBookCommand = new DeleteBookCommand(this);

            Thumbnail = selectedBook.thumbnail;
            Author = selectedBook.authors;
            Title = selectedBook.title;

            this.selectedBook = selectedBook;
        }

        public  void DeleteBook()
        {
            App.Connection.CreateTable<Book>();
            int bookDeleted = App.Connection.Delete(selectedBook);
            if (bookDeleted >= 1)
            {
                App.Current.MainPage.DisplayAlert("Success!", "The book is successfully deleted.", "Ok");
                App.Current.MainPage.Navigation.PopAsync();
            }
            else
                App.Current.MainPage.DisplayAlert("Failed!", "An error has occured.", "Ok");
        }
    }
}
