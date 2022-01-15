namespace InternetShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }

        public OrderStatus Status { get; set; }
        public string PostPoint { get; set; }
        public List<ProductInCart> Products { get; set; } = new();
        public User User { get; set; }

    }

    public enum OrderStatus
    {
        Processing,
        Shipping,
        Receiving,
        Received
    }
}
