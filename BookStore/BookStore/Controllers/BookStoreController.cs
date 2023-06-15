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

        public BookModel GetBook(int id)
        {
            return _repository.GetBook(id);
        }
        public List<BookModel> SearchBooks(string bookName,string authorName)
        {
            return _repository.SearchBook(bookName,authorName);
        }
    }
}
