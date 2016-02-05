using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Services
{
    public class BookService : IBookService 
    {

        readonly private BookViewModel _model;

        public BookService(BookViewModel model)
        {
            _model = model;
        }

        // public int Id { get; set; } I think, this is not assigned this way...
        public void AssignUser(string userId)
        {
            _model.UserId = userId;
        }

        public void AssignGenre(int? genreId)
        {
            _model.GenreId = genreId;
        }

        public void AssignTitle(string title)
        {
            _model.Title = title;
        }

        public void AssignBorrow(bool isBorrowed)
        {
            _model.IsBorrowed = isBorrowed;
        }
    }
}