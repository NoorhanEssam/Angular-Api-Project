using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
       [Required]
        public string Title { get; set; }
        [Required]
        public string SerailNumber { get; set; }
        [Required] 
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string Summary { get; set; }
        public DateTime? PublishDate { get; set; }
        public List<Quotes> Quotes { get; set; }
          [Required] 
        //[ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        //[ForeignKey("Publisher")]
        [Required]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public Int64 countDownload { get; set; }
        public string ImagePath { get; set; }
        public string BookPath { get; set; }
        [NotMapped]
        public IFormFile BookFile { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
