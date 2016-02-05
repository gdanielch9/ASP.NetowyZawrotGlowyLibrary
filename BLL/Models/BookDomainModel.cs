using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BLL.Models
{
    public class BookDomainModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsBorrowed { get; set; }

        [ForeignKey("Genre")]
        public int? GenreId { get; set; }
        public virtual GenreDomainModel Genre { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }

        public BookDomainModel() { IsBorrowed = false; }   // unnecessary
    }
}