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
                new BookModel() {Id=1,Title="Asp.Net Core MVC",Author="Suraj",Description="The ASP.NET MVC framework is a lightweight, highly testable presentation framework that (as with Web Forms-based applications) is integrated with existing ASP.NET features, such as master pages and membership-based authentication. The MVC framework is defined in the System.",Category="Framework",Language="English",TotalPages=143},
                new BookModel() {Id=2,Title="C",Author="Ram",Description="C is a powerful general-purpose programming language. It can be used to develop software like operating systems, databases, compilers, and so on. C programming is an excellent language to learn to program for beginners.",Category="Programming",Language="Nepali",TotalPages=243},
                new BookModel() {Id=3,Title="C++",Author="Sam",Description="C++ is an object-oriented programming language which gives a clear structure to programs and allows code to be reused, lowering development costs. C++ is portable and can be used to develop applications that can be adapted to multiple platforms. C++ is fun and easy to learn!",Category="Programming",Language="Chinease",TotalPages=343},
                new BookModel() {Id=4,Title="Python",Author="Hari",Description="Python is a computer programming language often used to build websites and software, automate tasks, and conduct data analysis. Python is a general-purpose language, meaning it can be used to create a variety of different programs and isn't specialized for any specific problems.",Category="Programming",Language="Russian",TotalPages=443},
                new BookModel() {Id=5,Title="Java",Author="Alex",Description="Java is a widely-used programming language for coding web applications. It has been a popular choice among developers for over two decades, with millions of Java applications in use today. Java is a multi-platform, object-oriented, and network-centric language that can be used as a platform in itself.",Category="Programming",Language="French",TotalPages=543},
            };
        }
    }
}
