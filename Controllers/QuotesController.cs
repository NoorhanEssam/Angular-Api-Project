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
    public class QuotesController : ControllerBase
    {
        private readonly Context context;
        public QuotesController(Context context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult<Quotes> GetQuotes()
        {
            List<Quotes> quotes = context.Quotes.ToList();
            return Ok(quotes);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Quotes> GetQuotes(int id)
        {
            var quotes = context.Quotes.FirstOrDefault(q => q.Id == id);
            if (quotes != null)
            {
                return Ok(quotes);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<Quotes> PostQuotes([FromForm]Quotes quotes)
        {
            if (ModelState.IsValid)
            {
                context.Quotes.Add(quotes);
                context.SaveChanges();
                return CreatedAtAction("GetQuotes", new { id = quotes.Id }, quotes);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Quotes> PutQuotes(int id, [FromForm]Quotes quotes)
        {
            if (id != quotes.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                context.Quotes.Update(quotes);
                context.SaveChanges();
                return quotes;
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Quotes> DeleteQuotes(int id) 
        {
            var quotes = context.Quotes.Find(id);
            if (quotes!=null)
            {
                context.Quotes.Remove(quotes);
                context.SaveChanges();
                return quotes;
            }
            return NotFound();
        }
    }
}
