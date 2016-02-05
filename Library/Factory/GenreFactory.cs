using BLL.Models;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Factory
{
    public static class GenreFactory
    {
        public static GenreViewModel Create(GenreDomainModel genreDomain)
        {
            return new GenreViewModel
            {
                Id = genreDomain.Id,
                Name = genreDomain.Name
            };
        }

        public static GenreViewModel CreateGenre(this GenreDomainModel genreDomain)
        {
            return Create(genreDomain);
        }

        public static GenreDomainModel Create(GenreViewModel genreView)
        {
            return new GenreDomainModel
            {
                Id = genreView.Id,
                Name = genreView.Name
            };
        }

        public static GenreDomainModel CreateGenre(this GenreViewModel genreView)
        {
            return Create(genreView);
        }
    }
}