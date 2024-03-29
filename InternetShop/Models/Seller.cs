﻿namespace InternetShop.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Product> Products { get; set; } = new();
        public List<User> Users { get; set; } = new();
    }
}
