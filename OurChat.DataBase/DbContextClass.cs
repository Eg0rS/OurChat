using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OurChat.Models.DomainModels;

namespace OurChat.DataBase;

public class DbContextClass : DbContext
{
    private readonly IConfiguration _configuration;

    public DbContextClass(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<Product> Products { get; set; }
}