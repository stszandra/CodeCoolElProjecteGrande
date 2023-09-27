using Microsoft.EntityFrameworkCore;
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Model;

public class OasisContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    public DbSet<Test> Test {get; set; }
    

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=test2;User Id=sa;Password=Kiskutyafüle32!;TrustServerCertificate=True");
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
        
        builder.Entity<Test>()
            .HasIndex(t => t.Id)
            .IsUnique();
        
        builder.Entity<Test>();

    }
}