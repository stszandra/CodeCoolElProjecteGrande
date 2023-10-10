﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class UsersContext : IdentityUserContext<IdentityUser>
{
    public UsersContext (DbContextOptions<UsersContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // TODO: It would be a good idea to move the connection string to user secrets
        options.UseSqlServer("Server=localhost,1433;Database=testDB;User Id=sa;Password=Kiskutyafüle32!;TrustServerCertificate=True;");

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}