using System;
using System.ComponentModel.DataAnnotations;

namespace BookService.Models
{
    public class Book
    {
        [Key]
        public Guid BookId { get; set; }

        [Required, StringLength(80)]
        public string BookName { get; set; }

        [Required, StringLength(80)]
        public string AuthorName { get; set; }

        public Guid AuthorId { get; set; }

        [Required]
        public DateTime DatePublished { get; set; }

        [Required, StringLength(80)]
        public string Publication { get; set; }

        [Required, StringLength(80)]
        public string Publisher { get; set; }

        [Required, StringLength(255)]
        public string About { get; set; }
    }
}
