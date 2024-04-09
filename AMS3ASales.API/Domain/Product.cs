namespace AMS3ASales.API.Domain
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Stock {  get; set; } 
        public string ImageURL { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
