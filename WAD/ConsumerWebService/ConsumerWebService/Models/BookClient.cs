using ConsumerWebService.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumerWebService.Models
{
    public class BookClient
    {
        BookServiceClient client = new BookServiceClient();
        public List<Book> getAllBook()
        {
            // Call list from service
            var list = client.GetBookList().ToList();
            // List client
            var rt = new List<Book>();
            // Gan list service cho list client
            list.ForEach(b => rt.Add(new Book()
            { BookId = b.BookId, ISBN = b.ISBN, Title = b.Title }));
            //
            return rt;
        }
    }
}