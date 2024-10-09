using Microsoft.EntityFrameworkCore;
using OrderManager.Common.Models;

namespace OrderManager.Data
{
  public class OrderManagerDbContext : DbContext
  {
    public OrderManagerDbContext(DbContextOptions<OrderManagerDbContext> options) : base(options)
    {
    }

    public DbSet<Orders> Orders { get; set; }
    public DbSet<Clients> Clients { get; set; }
    public DbSet<OrdersDetails> OrdersDetails { get; set; }
    public DbSet<Products> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Orders>()
        .HasOne(o => o.Client)
        .WithMany(c => c.Orders)
        .HasForeignKey(o => o.ClientId);

      modelBuilder.Entity<OrdersDetails>()
        .HasOne(d => d.Order)
        .WithMany(o => o.OrdersDetails)
        .HasForeignKey(d => d.OrderId);

      modelBuilder.Entity<OrdersDetails>()
        .HasOne(d => d.Product)
        .WithMany(p => p.OrdersDetails)
        .HasForeignKey(d => d.ProductId);
    }
  }
}