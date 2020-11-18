using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTvsWCF.Respository
{
    public interface IBookRepository
    {
        List<Book> GetAllBook();
        Book GetBookById(int id);
        Book AddNewBook(Book item);
        bool DeleteBook(int id);
        bool UpdateBook(Book item);
    }
}
