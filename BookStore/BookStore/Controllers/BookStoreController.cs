using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookStoreController : Controller
    {
        public readonly BookRepository _repository;

        public BookStoreController(BookRepository bookRepository)
        {
            _repository = bookRepository;
        }

       public async Task<ViewResult> GetAllBooks()
        {
            var data = await _repository.GetAllBooks();
            return View(data);
        }

        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _repository.GetBook(id);
            return View(data);
        }
        public List<BookModel> SearchBooks(string bookName,string authorName)
        {
            return _repository.SearchBook(bookName,authorName);
        }

        public ViewResult AddNewBook(bool IsSucess = false,int bookId =0)
        {
            ViewBag.IsSucess = IsSucess;
            ViewBag.BookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
           if(ModelState.IsValid)
            {
                var id = await _repository.AddBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction("AddNewBook", new { IsSucess = true, bookId = id });
                }
            }
            ModelState.AddModelError("","This is a custome model validation ");
            return View();
        }
    }
}
