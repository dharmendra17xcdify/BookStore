using BookService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Data
{
    public interface IInventoryData
    {
        IEnumerable<BookInventory> GetInventoryByBookName(string name);
        BookInventory GetById(Guid id);
        BookInventory Update(BookInventory updatedInventory);
        BookInventory Add(BookInventory newInventory);
        BookInventory Delete(Guid id);
        int GetCountOfInventory();
        int Commit();
    }
}
