using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Database
{
    public class AdminDbContext : IdentityDbContext<IdentityUser>
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Make connection Client.Cart => Cart.Owner
            builder.Entity<Cart>()
                .HasOne(c => c.Owner)
                .WithOne(c => c.Cart)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Make connection Order.Owner => Client.Orders
            builder.Entity<Order>()
                .HasOne(o => o.Owner)
                .WithMany(c => c.Orders)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Make connection OrderItem.Order => Order.OrderItems
            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Owner)
                .WithMany(o => o.OrderItems)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
