using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.Services
{
    public class GenreServicecs : IGenreService
    {
        public void AssignName(GenreDomainModel model, string name)
        {
            model.Name = name;
        }
    }
}