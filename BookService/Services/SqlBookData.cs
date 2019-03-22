using BookService.Data;
using BookService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Services
{
    public class SqlBookData : IBookData
    {
        private BookDatabaseContext db;

        public SqlBookData(BookDatabaseContext db)
        {
            this.db = db;
        }

        public Book Add(Book newBook)
        {
            db.Add(newBook);
            return newBook;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Book Delete(Guid id)
        {
            var book = GetById(id);
            if (book != null)
            {
                db.Books.Remove(book);
            }
            return book;
        }

        public IEnumerable<Book> GetBooksByName(string name)
        {
            var query = from r in db.Books
                        where r.BookName.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.BookName
                        select r;
            return query;
        }

        public Book GetById(Guid id)
        {
            return db.Books.Find(id);
        }

        public int GetCountOfBooks()
        {
            return db.Books.Count();
        }

        public Book Update(Book updatedBook)
        {
            var entity = db.Books.Attach(updatedBook);
            entity.State = EntityState.Modified;
            return updatedBook;
        }
    }
}
