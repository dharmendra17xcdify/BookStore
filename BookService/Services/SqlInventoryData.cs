using BookService.Data;
using BookService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Services
{
    public class SqlInventoryData : IInventoryData
    {
        private BookDatabaseContext db;

        public SqlInventoryData(BookDatabaseContext db)
        {
            this.db = db;
        }
        public BookInventory Add(BookInventory newInventory)
        {
            db.Add(newInventory);
            return newInventory;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public BookInventory Delete(Guid id)
        {
            var inventory = GetById(id);
            if (inventory != null)
            {
                db.Inventory.Remove(inventory);
            }
            return inventory;
        }

        public BookInventory GetById(Guid id)
        {
            return db.Inventory.Find(id);
        }

        public int GetCountOfInventory()
        {
            return db.Inventory.Count();
        }

        public IEnumerable<BookInventory> GetInventoryByBookName(string name)
        {
            var query = from r in db.Inventory
                        where r.BookName.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.BookName
                        select r;
            return query;

        }

        public BookInventory Update(BookInventory updatedInventory)
        {
            var entity = db.Inventory.Attach(updatedInventory);
            entity.State = EntityState.Modified;
            return updatedInventory;
        }
    }
}
