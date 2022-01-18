namespace InternetShop.Models
{
    public class ProductOnSell
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public int Amount { get; set; }
        public DateTime LastEdit { get; set; }
        public Product Product { get; set; }
        public List<ProductInCart> ProductInCarts { get; set; } = new();
    }
}
