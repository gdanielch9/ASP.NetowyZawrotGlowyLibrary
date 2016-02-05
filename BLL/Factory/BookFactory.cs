using BLL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.Factory
{
    public static class BookFactory
    {
        public static Book Create(BookDomainModel bookDomain)
        {
            return new Book
            {
                Id = bookDomain.Id,
                Title = bookDomain.Title,
                IsBorrowed = bookDomain.IsBorrowed,
                GenreId = bookDomain.GenreId,
                UserId = bookDomain.UserId
            };
        }

        public static Book CreateBook(this BookDomainModel bookDomain)
        {
            return Create(bookDomain);
        }

        public static BookDomainModel Create(Book book)
        {
            return new BookDomainModel
            {
                Id = book.Id,
                Title = book.Title,
                IsBorrowed = book.IsBorrowed,
                GenreId = book.GenreId,
                UserId = book.UserId
            };
        }

        public static BookDomainModel CreateBook(this Book book)
        {
            return Create(book);
        }
    }
}