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
        /// <param name="inventory"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateInventory([FromBody] BookInventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            inventory.InventoryId = Guid.NewGuid();
            _context.Inventory.Add(inventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllInventory", new { inventoryId = inventory.InventoryId }, inventory);
        }

        /// <summary>
        /// Update Inventory Info
        /// </summary>
        /// <param name="inventoryId"></param>
        /// <param name="inventory"></param>
        /// <returns></returns>
        [HttpPut("{inventoryId}")]
        public async Task<IActionResult> UpdateInventoryInfo(Guid inventoryId, [FromBody] BookInventory inventory)
        {
            inventory.InventoryId = inventoryId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(inventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(inventoryId))
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
        /// Detete a Inventory
        /// </summary>
        /// <param name="inventoryId"></param>
        /// <returns></returns>
        [HttpDelete("{inventoryId}")]
        public async Task<IActionResult> DeleteInventory([FromRoute] Guid inventoryId)
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

            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();

            return Ok(inventory);
        }

        /// <summary>
        /// Check Inventory exists
        /// </summary>
        /// <param name="inventoryId"></param>
        /// <returns></returns>
        private bool InventoryExists(Guid inventoryId)
        {
            return _context.Inventory.Any(e => e.InventoryId == inventoryId);
        }
    }
}
