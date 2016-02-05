using BLL.Models;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Factory
{
    public static class BookFactory
    {
        public static BookViewModel Create(BookDomainModel bookDomain)
        {
            return new BookViewModel
            {
                Id = bookDomain.Id,
                Title = bookDomain.Title,
                IsBorrowed = bookDomain.IsBorrowed,
                GenreId = bookDomain.GenreId,
                UserId = bookDomain.UserId
            };
        }

        public static BookViewModel CreateBook(this BookDomainModel bookDomain)
        {
            return Create(bookDomain);
        }

        public static BookDomainModel Create(BookViewModel bookView)
        {
            return new BookDomainModel
            {
                Id = bookView.Id,
                Title = bookView.Title,
                IsBorrowed = bookView.IsBorrowed,
                GenreId = bookView.GenreId,
                UserId = bookView.UserId
            };
        }

        public static BookDomainModel CreateBook(this BookViewModel bookView)
        {
            return Create(bookView);
        }
    }
}