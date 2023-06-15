using BookStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBook(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string title,string authorName)
        {
            //instead of using "==" better to use "contains()" method
            return DataSource().Where(x =>x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            { 
                new BookModel() {Id=1,Title="MVC",Author="Suraj",Description="This is the description for MVC"},
                new BookModel() {Id=2,Title="C",Author="Ram",Description="This is the description for C"},
                new BookModel() {Id=3,Title="C++",Author="Sam",Description="This is the description for C++"},
                new BookModel() {Id=4,Title="Python",Author="Hari",Description="This is the description for Python"},
                new BookModel() {Id=5,Title="Java",Author="Alex",Description="This is the description for Java"},
            };
        }
    }
}
