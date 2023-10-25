using Microsoft.EntityFrameworkCore;
using OfferOasisBackend.Model;
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Data;

public class OasisContext : DbContext
{
    public DbSet<Product?> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // TODO: It would be a good idea to move the connection string to user secrets

        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=OfferOasisDB;User Id=sa;Password=Kiskutyafüle32!;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
            .HasIndex(u => u.Name)
            .IsUnique();
        
        builder.Entity<Product>()
            .HasData(new Product(1,"PS3",ProductType.Konzol,1500,10));
        
        builder.Entity<Order>()
            .HasIndex(u => u.Id)
            .IsUnique();
        
        builder.Entity<Order>()
            .HasData(new Order(1,1,"ABC","DGS",ShippingType.Delivery,4500));
                      
        builder.Entity<OrderDetails>()
            .HasIndex(r => r.OrderDetailsId)
            .IsUnique();

        builder.Entity<OrderDetails>()
            .HasData(new OrderDetails(1,1,1,10));
    }
}

