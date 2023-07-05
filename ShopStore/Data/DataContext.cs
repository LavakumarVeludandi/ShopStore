using System;
using Microsoft.EntityFrameworkCore;
using ShopStore.Models;

namespace ShopStore.Data;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("PostgreSQL"));
    }

    public DbSet<User> Users { get; set; }
}

