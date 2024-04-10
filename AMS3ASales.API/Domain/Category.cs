namespace AMS3ASales.API.Domain
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string ImageURL { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
