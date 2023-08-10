using CoffeeShop.EntityFramework.Models;
using Spectre.Console;
using System.Windows.Markup;

namespace CoffeeShop.EntityFramework;

internal class ProductController
{
    internal static void AddProduct(Product product)
    {
        using var db = new ProductContext();
        db.Add(new Product { Name = product.Name, Price = product.Price });
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
        var product = db.Products.SingleOrDefault(p => p.Id == id);

        return product;
    }

    internal static List<Product> GetProducts()
    {
        using var db = new ProductContext();

        var products = db.Products.ToList();

        return products;
    }

    internal static void UpdateProduct(Product product)
    {
        using var db = new ProductContext();
        db.Update(product);
        db.SaveChanges();
    }
}
