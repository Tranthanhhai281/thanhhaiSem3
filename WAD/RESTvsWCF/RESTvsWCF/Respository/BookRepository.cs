using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTvsWCF.Respository
{
    public class BookRepository : IBookRepository
    {
        private List<Book> books = new List<Book>();
        private int counter = 1;
        public BookRepository()
        {
            AddNewBook(new Book() { Title = "C# programming", ISBN = "123456789" });
            AddNewBook(new Book() { Title = "Java programming", ISBN = "123456789" });
            AddNewBook(new Book() { Title = "PHP programming", ISBN = "123456789" });
            AddNewBook(new Book() { Title = "Python programming", ISBN = "123456789" });
            AddNewBook(new Book() { Title = "Scala programming", ISBN = "123456789" });
        }
        public Book AddNewBook(Book item)
        {
            if (item == null)
            {
                throw new ArgumentException("No argument");
            }
            item.BookId = counter++;
            books.Add(item);
            return item;
        }

        public bool DeleteBook(int id)
        {
            int idx = books.FindIndex(b => b.BookId == id);
            if (idx == -1)
            {
                return false;
            }
            books.RemoveAll(b => b.BookId == id);
            return true;
            //throw new NotImplementedException();
        }

        public List<Book> GetAllBook()
        {
            return books;
            //throw new NotImplementedException();
        }

        public Book GetBookById(int id)
        {
            return books.Find(b => b.BookId == id);
            //throw new NotImplementedException();
        }

        public bool UpdateBook(Book bookUpdate)
        {
            if (bookUpdate == null)
            {
                throw new ArgumentNullException("Not update book");
            }
            int idx = books.FindIndex(b => b.BookId == bookUpdate.BookId);
            if (idx == -1)
            {
                return false;
            }
            books.RemoveAt(idx);
            books.Add(bookUpdate);
            return true;
            //throw new NotImplementedException();
        }
    }
}