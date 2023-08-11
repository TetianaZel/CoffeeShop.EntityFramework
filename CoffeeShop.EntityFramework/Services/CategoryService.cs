using CoffeeShop.EntityFramework.Controllers;
using CoffeeShop.EntityFramework.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EntityFramework.Services
{
    internal class CategoryService
    {
        internal static void GetAllCategories()
        {
            var categories = CategoryController.GetCategories();
            UserInterface.ShowCategoryTable(categories);
        }

        internal static void InsertCategory()
        {
            var category = new Category();
            category.Name = AnsiConsole.Ask<string>("Category's name:");
            CategoryController.AddCategory(category);
        }

        static internal Category GetCategoryOptionInput()
        {
            var categories = CategoryController.GetCategories();
            var categoriesArray = categories.Select(x => x.Name).ToArray();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("ChooseCategory")
                .AddChoices(categoriesArray));
            var category = categories.Single(x => x.Name == option);

            return category;
        }

        internal static void DeleteCategory()
        {
            var category = GetCategoryOptionInput();
            CategoryController.DeleteCategory(category);
        }

        internal static void UpdateCategory()
        {
            var categoryToUpdate = GetCategoryOptionInput();

            categoryToUpdate.Name = AnsiConsole.Confirm("Update Name?")
                ? AnsiConsole.Ask<string>("Category's new name:")
                : categoryToUpdate.Name;

            CategoryController.UpdateCategory(categoryToUpdate);
        }

        internal static void GetCategory()
        {
            var category = GetCategoryOptionInput();
            UserInterface.ShowCategory(category);
        }
    }
}
