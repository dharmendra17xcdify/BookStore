using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Models
{
    public class Author
    {
        [Key]
        public Guid AuthorId { get; set; }

        [Required, StringLength(80)]
        public string AuthorName { get; set; }

        [Required, StringLength(80)]
        public string Genre { get; set; }

        [Required, StringLength(255)]
        public string AboutAuther { get; set; }

        [Required, StringLength(255)]
        public string Awards { get; set; }

        [Required, StringLength(255)]
        public string Books { get; set; }

    }
}
