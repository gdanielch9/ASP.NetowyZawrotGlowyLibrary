using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Services
{
    public class GenreServicecs : IGenreService
    {
        public readonly GenreViewModel _model;

        public GenreServicecs(GenreViewModel model)
        {
            _model = model;
        }

        public void AssignName(string name)
        {
            _model.Name = name;
        }
    }
}