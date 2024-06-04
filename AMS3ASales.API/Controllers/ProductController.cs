using AMS3ASales.API.Context;
using AMS3ASales.API.Domain;
using AMS3ASales.API.Domain.DTO;
using AMS3ASales.API.Domain.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMS3ASales.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AplicationDataContext _context;
        public ProductController(AplicationDataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _context.Product.ToListAsync();
            if (products == null)
                return NotFound();

            var response = new List<ProductDTO>();

            foreach (var product in products)
            {
                response.Add(new ProductDTO
                {
                    Id = product.Id,
                    Description = product.Description,
                    Price = product.Price,
                    Stock = product.Stock,
                    ImageURL = product.ImageURL
                });
            }
            return Ok(response);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public ActionResult<Product> GetId(Guid id)
        {
            var product = _context.Product.FirstOrDefault(c => c.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public ActionResult Post(ProductRequest productRequest) 
        {
            var product = new Product()
            {
                Description = productRequest.Description,
                Price = productRequest.Price,
                Stock = productRequest.Stock,
                ImageURL = productRequest.ImageURL,
                CategoryId = productRequest.CategoryId,
                CreateDate = DateTime.Now,
                IsActive = true
            };
            _context.Product.Add(product);
            _context.SaveChanges();

            return Ok();
        }
        
    }
}
