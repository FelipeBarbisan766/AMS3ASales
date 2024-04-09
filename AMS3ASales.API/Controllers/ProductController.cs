using AMS3ASales.API.Context;
using AMS3ASales.API.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _context.Product.ToList();
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
        public ActionResult Post(Product product) 
        {
            _context.Product.Add(product);
            _context.SaveChanges();

            return Ok();
        }
        
    }
}
