using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksWishlistApp.Models
{
    public class Book
    {
        [JsonIgnore]
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string thumbnail { get; set; }
        public string title { get; set; }
        public string authors { get; set; }
    }
}
