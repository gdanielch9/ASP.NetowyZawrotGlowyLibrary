using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Models;

namespace BLL.Services
{
    public class BookService : IBookService 
    {

        // public int Id { get; set; } I think, this is not assigned this way...
        public void AssignUser(BookDomainModel model, string userId)
        {
            model.UserId = userId;
        }

        public void AssignGenre(BookDomainModel model, int? genreId)
        {
            model.GenreId = genreId;
        }

        public void AssignTitle(BookDomainModel model, string title)
        {
            model.Title = title;
        }

        public void AssignBorrow(BookDomainModel model, bool isBorrowed)
        {
            model.IsBorrowed = isBorrowed;
        }
    }
}