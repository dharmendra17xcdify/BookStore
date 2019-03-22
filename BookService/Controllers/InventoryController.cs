using BookService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly BookDatabaseContext _context;

        public InventoryController(BookDatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get All Inventory
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<BookInventory>> GetAllInventory()
        {
            return _context.Inventory;
        }

        /// <summary>
        /// Get Inventory By Id
        /// </summary>
        /// <param name="inventoryId"></param>
        /// <returns></returns>
        [HttpGet("{inventoryId}")]
        public async Task<IActionResult> GetInventoryById([FromRoute] Guid inventoryId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventory = await _context.Inventory.FindAsync(inventoryId);

            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }

        /// <summary>
        /// Create a New Inventory
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookInventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //book.BookId = Guid.NewGuid();
            //_context.Books.Add(book);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooks", new { inventoryId = inventory.InventoryId }, inventory);
        }

        /// <summary>
        /// Update Book Info
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut("{bookId}")]
        public async Task<IActionResult> UpdateBookInfo(Guid bookId, [FromBody] Book book)
        {
            book.BookId = bookId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //_context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(bookId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Detete a Book
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBook([FromRoute] Guid bookId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await _context.Books.FindAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Ok(book);
        }

        /// <summary>
        /// Check book exists
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        private bool BookExists(Guid bookId)
        {
            return _context.Books.Any(e => e.BookId == bookId);
        }
    }
}
