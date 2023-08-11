using CoffeeShop.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;
using System.Windows.Markup;

namespace CoffeeShop.EntityFramework.Controllers;

internal class ProductController
{
    internal static void AddProduct(Product product)
    {
        using var db = new ProductContext();
        db.Add(new Product { Name = product.Name, Price = product.Price, CategoryId = product.CategoryId});
        db.SaveChanges();
    }

    internal static void DeleteProduct(Product product)
    {
        using var db = new ProductContext();
        db.Remove(product);
        db.SaveChanges();
    }

    internal static Product GetProductById(int id)
    {
        using var db = new ProductContext();
        var product = db.Products
            .Include(x => x.Category)
            .SingleOrDefault(p => p.ProductId == id);

        return product;
    }

    internal static List<Product> GetProducts()
    {
        using var db = new ProductContext();

        var products = db.Products
            .Include(x => x.Category)
            .ToList();

        return products;
    }

    internal static void UpdateProduct(Product product)
    {
        using var db = new ProductContext();
        db.Update(product);
        db.SaveChanges();
    }
}
