using CoffeeShop.EntityFramework;
using Spectre.Console;
using static CoffeeShop.EntityFramework.Enums;

var context = new ProductContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();


UserInterface.MainMenu();

