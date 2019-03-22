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
    public class AuthorsController : ControllerBase
    {
        private readonly BookDatabaseContext _context;

        public AuthorsController(BookDatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get All authors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Author>> Getauthors()
        {
            return _context.Authors;
        }

        /// <summary>
        /// Get Author By Id
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        [HttpGet("{authorId}")]
        public async Task<IActionResult> GetAuthorById([FromRoute] Guid authorId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var author = await _context.Authors.FindAsync(authorId);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        /// <summary>
        /// Create a New Author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            author.AuthorId = Guid.NewGuid();
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthors", new { AuthorId = author.AuthorId }, author);
        }

        /// <summary>
        /// Update Author Info
        /// </summary>
        /// <param name="authorId"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPut("{authorId}")]
        public async Task<IActionResult> UpdateAuthorInfo(Guid authorId, [FromBody] Author author)
        {
            author.AuthorId = authorId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(authorId))
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
        /// Detete a Author
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        [HttpDelete("{authorId}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] Guid authorId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var author = await _context.Authors.FindAsync(authorId);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return Ok(author);
        }

        /// <summary>
        /// Check author exists
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        private bool AuthorExists(Guid authorId)
        {
            return _context.Authors.Any(e => e.AuthorId == authorId);
        }
    }
}
