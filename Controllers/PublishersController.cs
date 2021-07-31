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
    public class PublishersController : ControllerBase
    {
       private readonly Context context;
        public PublishersController(Context context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult<Publisher> GetPublishers()
        {
            List<Publisher> publishers = context.Publishers.ToList();
            return Ok(publishers);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Publisher> GetPublishers([FromRoute] int id)
        {
            var publisher = context.Publishers.FirstOrDefault(p=>p.Id==id);
            if (publisher!=null)
            {
                return Ok(publisher);
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<Publisher> PostPublisher([FromBody]Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                context.Publishers.Add(publisher);
                context.SaveChanges();
                return CreatedAtAction("GetPublishers", new { id=publisher.Id},publisher);
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Publisher> PutPublishers([FromRoute] int id,[FromBody] Publisher publisher)
        {
            if (id!=publisher.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                context.Publishers.Update(publisher);
                context.SaveChanges();
                return Ok(publisher);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeletePublishers(int id)
        {
            var publishers = context.Publishers.Find(id);
            if (publishers!=null)
            {
                context.Publishers.Remove(publishers);
                context.SaveChanges();
                return Ok(publishers);
            }
            return NotFound();
        }
    }
}
