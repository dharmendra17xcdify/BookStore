using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Models
{
    public class BookInventory
    {
        [Key]
        public Guid InventoryId { get; set; }

        [Required]
        public Guid BookId { get; set; }

        [Required, StringLength(80)]
        public string BookName { get; set; }

        [Required]
        public Guid AutherId { get; set; }

        [Required, StringLength(80)]
        public string AutherName { get; set; }

        [Required]
        public int BookQuantityAvail { get; set; }

        [Required]
        public int BookQuantitySold { get; set; }

        [Required]
        public int BookQuantityOnOrder { get; set; }

        public int? BookQuantityTotal { get; set; }
    }
}
