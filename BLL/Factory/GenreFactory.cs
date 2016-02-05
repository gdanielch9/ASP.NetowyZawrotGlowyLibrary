using BLL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.Factory
{
    public static class GenreFactory
    {
        public static Genre Create(GenreDomainModel genreDomain)
        {
            return new Genre
            {
                Id = genreDomain.Id,
                Name = genreDomain.Name
            };
        }

        public static Genre CreateGenre(this GenreDomainModel genreDomain)
        {
            return Create(genreDomain);
        }

        public static GenreDomainModel Create(Genre genre)
        {
            return new GenreDomainModel
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public static GenreDomainModel CreateGenre(this Genre genre)
        {
            return Create(genre);
        }
    }
}