using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectAPI.Models;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
       private readonly Context context;
        public AuthorsController(Context _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public ActionResult<Author> GetAuthors()
        {
            List<Author> authors = context.Authors.ToList();
            return Ok(authors);
        }

        [HttpGet]
        [Route("~/api/author/{id:int}")]
        public ActionResult<Author> GetAuthor([FromRoute]int id)
        {
            var author = context.Authors.FirstOrDefault(a=>a.Id==id);
            if (author!=null)
            {
                return Ok(author);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult PostAuthor([FromBody] Author author)
        {
            if (ModelState.IsValid)
            {
                
                context.Authors.Add(author);
            context.SaveChanges();
            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult PutAuthors([FromRoute]int id,[FromBody] Author model)
        {
           
            if (id!=model.Id)
            {
                return BadRequest();
            }
            else if (context.Authors.Any(a=>a.Id==id))
            {
                context.Authors.Update(model);
                context.SaveChanges();
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Author> DeleteAuthors([FromRoute]int id)
        {
            var author = context.Authors.Find(id);
            if (author==null)
            {
                return NotFound();
            }
            context.Authors.Remove(author);
            context.SaveChanges();
            return author;
        }
    }
}
