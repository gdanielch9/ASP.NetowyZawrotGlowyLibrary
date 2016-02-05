using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Controllers;
using Library.Content;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arange 
            HomeController home = new HomeController();

            //Act
            var result = home.About();

            //Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void TestM2()
        {
            BooksController book = new BooksController();

            var result = book.Create(new Library.Models.Book {
                Id = 1234,
                Title = "Tytuł"
                
            });

            Assert.IsNull(result);
        }
    }
}
