using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAPI.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [EmailAddress]
        public string Emial { get; set; }
        [ForeignKey("Publisher")]
        [Required]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public List<Book> Books { get; set; }
        public List<Quotes>Quotes { get; set; }
        public string ImagePath { get; set; }
    }
}
