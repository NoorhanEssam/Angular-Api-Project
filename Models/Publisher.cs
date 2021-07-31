using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAPI.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string WebSite { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }
        public string ImagePath { get; set; }

    }
}
