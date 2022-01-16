namespace InternetShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Shortname { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public Seller Seller { get; set; }
        public List<Tag> Tags { get; set; } = new();
        public List<ProductOnSell> Products { get; set; } = new();
        public List<Category> Categories { get; set; } = new();
    }
}
