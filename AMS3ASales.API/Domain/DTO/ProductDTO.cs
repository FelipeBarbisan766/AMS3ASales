namespace AMS3ASales.API.Domain.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; } 
        public string Description { get; set; }
        public double Price { get; set; }
        public double Stock { get; set; }
        public string ImageURL { get; set; }
    }
}
