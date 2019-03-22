using BookService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Data
{
    public interface IBookData
    {
        IEnumerable<Book> GetBooksByName(string name);
        Book GetById(Guid id);
        Book Update(Book updatedBook);
        Book Add(Book newBook);
        Book Delete(Guid id);
        int GetCountOfBooks();
        int Commit();
    }
}
