using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Persistence.Context
{
    public class OrderContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-141UAGI;initial catalog=MultiShopOrderDb;integrated security=true");
        }
        public DbSet<Ordering> Orderings { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
