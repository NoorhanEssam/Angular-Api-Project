using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectAPI.Models;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using FinalProjectAPI.Models;
using System.IO;
using System.Net.Http;
using System.Net;
using static System.Net.WebRequestMethods;
using System.Web;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Cors;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly Context _context;
        IWebHostEnvironment _webHostEnvironment;
        public BooksController(Context context, IWebHostEnvironment webHostEnvironment)
        {
            this._context = context;
            this._webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public ActionResult GetBooks()
        {
            List<Book> books = _context.Books.ToList();
            if (books.Count>0)
            {
                return Ok(books);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("~/api/book/{id:int}")]
        public ActionResult<Book> GetBook([FromRoute]int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book!=null)
            {
                return Ok(book);
            }
            return NotFound();
        }




        [HttpPost, DisableRequestSizeLimit]
        public ActionResult PostBooks([FromBody] Book model)
        {
            try
            {
                _context.Books.Add(model);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetBook), new { id = model.Id }, model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;

                var physicalPath = _webHostEnvironment.WebRootPath + "/uploads/" + filename;
                using (var stream = new FileStream(physicalPath, System.IO.FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("defbookcover.jpg");
            }
        }




        [Route("SaveBook")]
        [HttpPost]
        public JsonResult SaveBook()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;



                var physicalPath = _webHostEnvironment.WebRootPath + "/uploads/" + filename;
                using (var stream = new FileStream(physicalPath, System.IO.FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("");
            }
        }


        [HttpGet]
        [Route("Search/{name}")]
        public ActionResult GetBooks([FromRoute] string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                List<Book> books = _context.Books.Where(b => b.Title.ToLower().Contains(name.ToLower())).ToList();
                return Ok(books);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("Category/{id}")]
        public ActionResult GetBooks([FromRoute] int id)
        {
            List<Book> books = _context.Books.Where(b=>b.CategoryId==id).ToList();

            if (books!=null)
            {
                return Ok(books);
            }
            return NotFound();
        }

        [Route("~/api/books/download/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> loadFromPhsyical([FromRoute] int id)
        {

            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            var FileName = book.BookPath;
            string phsyicalPath = _webHostEnvironment.WebRootPath + "\\uploads\\" + FileName;
            book.countDownload += 1;
            _context.Books.Update(book);
            _context.SaveChanges();
            byte[] pdfbytes = await System.IO.File.ReadAllBytesAsync(phsyicalPath);

            MemoryStream ms = new MemoryStream(pdfbytes);

            return new FileStreamResult(ms, "application/pdf");
        }


        [HttpDelete]
        public ActionResult<Book> DeleteBook([FromRoute] int id)
        {
            var book = _context.Books.FirstOrDefault(d=>d.Id==id);
            if (book!=null)
            {
                string FileName = book.BookPath;
                string ImageName = book.ImagePath;
                string filePathBook = _webHostEnvironment.WebRootPath + "\\uploads\\" + FileName;
                string filePathImage = _webHostEnvironment.WebRootPath + "\\uploads\\" + ImageName;
                if (System.IO.File.Exists(filePathBook))
                {
                    System.IO.File.Delete(filePathBook);
                }
                if (System.IO.File.Exists(filePathImage))
                {
                    System.IO.File.Delete(filePathImage);
                }
                _context.Books.Remove(book);
                _context.SaveChanges();
                return book;
            }
            return NotFound();
        }

        [HttpGet]
        [Route("~/api/books/suggest")]
        public ActionResult<Book> GetSuggest()
        {
            var random = new Random();
            //var Suggest = _context.Books.OrderBy(b => random.Next()).Select(b => new { b.Title, b.ImagePath, b.Id }).Take(5);
            //return Ok(Suggest);
            var Suggest = _context.Books.Select(b => new { b.Title, b.ImagePath, b.Id }).OrderBy(x => Guid.NewGuid()).Take(8);
            return Ok(Suggest);
        }

        //[HttpGet]
        //[Route("~/api/books/r")]
        //public string GetRoute()
        //{
        //    return _webHostEnvironment.WebRootPath + "\\uploads\\";
        //}

    }
}
