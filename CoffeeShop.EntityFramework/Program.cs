using CoffeeShop.EntityFramework;
using Spectre.Console;
using static CoffeeShop.EntityFramework.Enums;

var isAppRunning = true;
while (isAppRunning)
{
    var option = AnsiConsole.Prompt(
    new SelectionPrompt<MenuOptions>()
    .Title("What would you like to do?")
    .AddChoices(
    MenuOptions.AddProduct,
    MenuOptions.DeleteProduct,
    MenuOptions.UpdateProduct,
    MenuOptions.ViewProduct,
    MenuOptions.ViewAllProducts
    ));

    switch (option)
    {
        case MenuOptions.AddProduct:
            ProductController.AddProduct();
            break;
        case MenuOptions.DeleteProduct:
            ProductController.DeleteProduct();
            break;
        case MenuOptions.UpdateProduct:
            ProductController.UpdateProduct();
            break;
        case MenuOptions.ViewProduct:
            ProductController.GetProductById();
            break;
        case MenuOptions.ViewAllProducts:
            ProductController.GetProducts();
            break;
    }
}

