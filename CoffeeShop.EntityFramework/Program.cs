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
            ProductService.InsertProduct();
            break;
        case MenuOptions.DeleteProduct:
            ProductService.DeleteProduct();
            break;
        case MenuOptions.UpdateProduct:
            ProductService.UpdateProduct();
            break;
        case MenuOptions.ViewProduct:
            ProductService.GetProduct();
            break;
        case MenuOptions.ViewAllProducts:
            ProductService.GetAllProducts();
            break;
    }
}

