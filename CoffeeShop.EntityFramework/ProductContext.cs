using CoffeeShop.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.EntityFramework;

internal class ProductContext: DbContext
{
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
       optionsBuilder.UseSqlite($"Data Source = products.db");
   
}
