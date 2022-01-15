namespace InternetShop.Models
{
    public class ProductInCart
    {
        public int Id { get; set; }
        public ProductOnSell Product { get; set; }
        public User User { get; set; }

    }
}
