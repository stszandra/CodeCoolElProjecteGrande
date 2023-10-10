﻿using Microsoft.EntityFrameworkCore;
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Model;

public class OasisContext : DbContext
{
    // public DbSet<Product> Products { get; set; }
    // public DbSet<Order> Orders { get; set; }
    // public DbSet<Rating> Ratings { get; set; }

    public DbSet<Test> Test {get; set; }
    

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=testDB;User Id=sa;Password=Kiskutyafüle32!;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
            .HasIndex(u => u.Name)
            .IsUnique();
        
        builder.Entity<Product>()
            .HasData(
                new Product(1,"PS3",ProductType.Konzol,1500,10)
            );
        
        builder.Entity<Order>()
            .HasIndex(u => u.Id)
            .IsUnique();
        
        builder.Entity<Order>()
            .HasData(
                new Order(1,1,"ABC","DGS",ShippingType.Delivery,4500)
            );
                      
        builder.Entity<OrderDetails>()
            .HasIndex(r => r.OrderDetailsId)
            .IsUnique();

        builder.Entity<OrderDetails>()
            .HasData(
                new OrderDetails(1,1,1,10)
                );





        // builder.Entity<Test>()
        //    .HasIndex(t => t.Id)
        //  .IsUnique();



    }
    
}

