using AMS3ASales.API.Context;
using AMS3ASales.API.Domain;
using AMS3ASales.API.Domain.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMS3ASales.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AplicationDataContext _context;
        public CategoriesController(AplicationDataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get() 
        {
            return _context.Category.ToList(); 
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public ActionResult<Category> GetId(Guid id)
        {
            var category = _context.Category.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            return Ok(category);
        }
        [HttpPost]
        public ActionResult Post(CategoryRequest categoryRequest){ 
            var category = new Category(){ 
                Description = categoryRequest.Description, 
                ImageURL = categoryRequest.ImageURL,
                IsActive = true
            };
            _context.Category.Add(category);
            _context.SaveChanges();
            return Ok();
        }
    }
}
