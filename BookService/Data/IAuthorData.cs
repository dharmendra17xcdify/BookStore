using BookService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Data
{
    public interface IAuthorData
    {
        IEnumerable<Author> GetAuthorsByName(string name);
        Author GetById(Guid id);
        Author Update(Author updatedAuthor);
        Author Add(Author newAuthor);
        Author Delete(Guid id);
        int GetCountOfAuthors();
        int Commit();
    }
}
