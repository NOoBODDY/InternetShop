using Microsoft.EntityFrameworkCore;
namespace InternetShop.Models
{
    public class Context:DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductInCart> ProductInCarts { get; set; } = null!;
        public DbSet<ProductOnSell> ProductOnSells { get; set; } = null!;
        public DbSet<Seller> Sellers { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public Context(DbContextOptions<Context> options)
        : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";
            string sellerRoleName = "seller";
            string moderatorRoleName = "moderator";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            Role selerRole = new Role { Id = 3, Name = sellerRoleName };
            Role moderatorRole = new Role { Id = 4, Name = moderatorRoleName };
            User adminUser = new User { Id = 1, Login = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole, selerRole, moderatorRole});
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);

        }
    }
}
