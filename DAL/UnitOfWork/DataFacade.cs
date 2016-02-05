using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.UnitOfWork
{
    public class DataFacade
    {
        private ApplicationDbContext _dbContext;
        private BookRepository _books;

        public DataFacade(ApplicationDbContext dbContext)
        {
            CreateDbContext(dbContext);
        }

        protected void CreateDbContext(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? new ApplicationDbContext();

        }
//#endregion Czegoś brakuje

        public BookRepository Books
        {
            get
            {
                return _books ?? (_books = new BookRepository(_dbContext));
            }
        }
    }
}