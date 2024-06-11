using AMS3ASales.API.Context;
using AMS3ASales.API.Domain;
using AMS3ASales.API.Domain.DTO;
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
        public async Task<ActionResult<IEnumerable<CategoryDTO>>>  Get() 
        {
            var categories = await _context.Category.Where(c => c.IsActive == true).ToListAsync();
            if (categories == null)
                return NotFound();

            var response = new List<CategoryDTO>();
            
            foreach (var category in categories)
            {
                response.Add(new CategoryDTO
                {
                    Id = category.Id,
                    Description = category.Description,
                    ImageURL = category.ImageURL
                });
            }
                return Ok(response); 
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

        [HttpPut("{id:Guid}")]
        public IActionResult Put(Guid id, [FromBody] CategoryRequest categoryRequest)
        {
            var category = _context.Category.FirstOrDefault(c => c.Id == id);

            category.Description = categoryRequest.Description;
            category.ImageURL = categoryRequest.ImageURL;
            _context.SaveChanges();     

            return NoContent(); 
        }
        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            var category = _context.Category.FirstOrDefault(c => c.Id == id);

            category.IsActive = false;
            _context.SaveChanges();

            return NoContent();
        }

    }
}
