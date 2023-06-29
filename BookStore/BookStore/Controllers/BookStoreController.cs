using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookStore.Controllers
{
    public class BookStoreController : Controller
    {
        public readonly BookRepository _repository = new BookRepository();

        public BookStoreController()
        {
            _repository = new BookRepository();
        }

       public ViewResult GetAllBooks()
        {
            var data = _repository.GetAllBooks();
            return View(data);
        }

        public ViewResult GetBook(int id)
        {
            var data = _repository.GetBook(id);
            return View(data);
        }
        public List<BookModel> SearchBooks(string bookName,string authorName)
        {
            return _repository.SearchBook(bookName,authorName);
        }

        public ViewResult AddNewBook()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddNewBook(BookModel bookModel)
        {
            
            return View();
        }
    }
}
