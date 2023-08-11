using CoffeeShop.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EntityFramework.Controllers
{
    internal class CategoryController
    {
        internal static void AddCategory(Category category)
        {
            using var db = new ProductContext();
            db.Add(category);
            db.SaveChanges();
        }



        internal static List<Category> GetCategories() 
        {
            using var db = new ProductContext();
            var categories = db.Categories
                .Include(x => x.Products)
                .ToList();
            return categories;
        }

        internal static void DeleteCategory(Category category)
        {
            using var db = new ProductContext();
            db.Remove(category);
            db.SaveChanges();
        }

        internal static void UpdateCategory(Category category)
        {
            using var db = new ProductContext();
            db.Update(category);
            db.SaveChanges();
        }
    }
}
