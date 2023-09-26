using Microsoft.EntityFrameworkCore;
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Model;

public class OasisContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=WeatherApi;User Id=sa;Password=Kiskutyafüle32!");
        //trust credentials
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
            .HasIndex(u => u.Id)
            .IsUnique();
        
        builder.Entity<Order>()
            .HasIndex(o => o.Id)
            .IsUnique();
        
        builder.Entity<Product>();
        builder.Entity<Order>();

    }
}