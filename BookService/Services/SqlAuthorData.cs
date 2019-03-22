using BookService.Data;
using BookService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Services
{
    public class SqlAuthorData : IAuthorData
    {
        private BookDatabaseContext db;

        public SqlAuthorData(BookDatabaseContext db)
        {
            this.db = db;
        }

        public Author Add(Author newAuthor)
        {
            db.Add(newAuthor);
            return newAuthor;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Author Delete(Guid id)
        {
            var auther = GetById(id);
            if (auther != null)
            {
                db.Authors.Remove(auther);
            }
            return auther;
        }

        public IEnumerable<Author> GetAuthorsByName(string name)
        {
            var query = from r in db.Authors
                        where r.AuthorName.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.AuthorName
                        select r;
            return query;
        }

        public Author GetById(Guid id)
        {
            return db.Authors.Find(id);
        }

        public int GetCountOfAuthors()
        {
            return db.Authors.Count();
        }

        public Author Update(Author updatedAuthor)
        {
            var entity = db.Authors.Attach(updatedAuthor);
            entity.State = EntityState.Modified;
            return updatedAuthor;
        }
    }
}
