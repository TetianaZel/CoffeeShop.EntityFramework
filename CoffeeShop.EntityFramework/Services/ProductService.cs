﻿using CoffeeShop.EntityFramework.Controllers;
using CoffeeShop.EntityFramework.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EntityFramework.Services
{
    internal class ProductService
    {
        internal static void InsertProduct()
        {
            var product = new Product();
            product.Name = AnsiConsole.Ask<string>("Product's name:");
            product.Price = AnsiConsole.Ask<decimal>("Product's price:");
            product.CategoryId = CategoryService.GetCategoryOptionInput().CategoryId;
            ProductController.AddProduct(product);
        }

        internal static void GetAllProducts()
        {
            var products = ProductController.GetProducts();
            UserInterface.ShowProductTable(products);
        }

        internal static void GetProduct()
        {
            var product = GetProductOptionInput();
            UserInterface.ShowProduct(product);
        }
        static internal Product GetProductOptionInput()
        {
            var products = ProductController.GetProducts();
            var productsArray = products.Select(x => x.Name).ToArray();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("ChooseProduct")
                .AddChoices(productsArray));
            var id = products.Single(x => x.Name == option).ProductId;
            var product = ProductController.GetProductById(id);

            return product;
        }

        internal static void DeleteProduct()
        {
            var product = GetProductOptionInput();
            ProductController.DeleteProduct(product);
        }

        internal static void UpdateProduct()
        {
            var product = GetProductOptionInput();

            product.Name = AnsiConsole.Confirm("Update Name?")
                ? AnsiConsole.Ask<string>("Products's new name:")
                : product.Name;

            product.Price = AnsiConsole.Confirm("Update Price?")
                ? AnsiConsole.Ask<decimal>("Products's new price:")
                : product.Price;
            product.Category.Name = AnsiConsole.Confirm("Update Category?")
                ? AnsiConsole.Ask<string>("Products's new category:")
                : product.Category.Name;
            ProductController.UpdateProduct(product);
        }
    }
}
