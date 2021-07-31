using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class CategoriesController : ControllerBase
    {
        private readonly Context context;
        public CategoriesController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<Category> GetCategories()
        {
            List<Category> categories = context.Categories.ToList();
            return Ok(categories);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Category> GetCategories([FromRoute] int id)
        {
            var cateogry = context.Categories.Find(id);
            if (cateogry == null)
            {
                return NotFound();
            }
            return Ok(cateogry);
        }
        [HttpPost]
        public ActionResult PostCategory([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return CreatedAtAction("GetCategories", new { id = category.Id }, category);
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Category> PutCategory([FromRoute] int id,[FromBody] Category category)
        {
            if (id!=category.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                context.Categories.Update(category);
                context.SaveChanges();
                return Ok(category);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Category> DeleteCategory([FromRoute] int id)
        {
            var category = context.Categories.Find(id);
            if (category!=null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
                return category;
            }
            return BadRequest();
        }
    }
}
