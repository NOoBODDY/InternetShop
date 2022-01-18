namespace InternetShop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
        public List<ProductInCart> ShoppingCart { get; set; } = new();
        public List<Order> Orders { get; set; } = new();
        public Seller? Seller { get; set; } 
    }
}
