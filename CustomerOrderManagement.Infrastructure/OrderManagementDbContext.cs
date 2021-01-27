using CustomerOrderManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderManagement.Infrastructure
{
  public class OrderManagementDbContext : DbContext
  {
	public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options) : base(options)
	{
	}

	public DbSet<Product> Products { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<Customer> Customers { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
	  base.OnModelCreating(modelBuilder);
	  modelBuilder.Entity<Product>()
	   .Property(p => p.PricePerItem)
	   .HasColumnType("decimal(18,2)");

	  modelBuilder.Entity<Product>()
	   .Property(p => p.AverageCustomerRating)
	   .HasColumnType("decimal(3,2)");

	  modelBuilder.Entity<Order>()
		.Property(p => p.PricePaid)
		.HasColumnType("decimal(18,2)");
	}
  }
}