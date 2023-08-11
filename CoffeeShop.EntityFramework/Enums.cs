using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EntityFramework
{
    internal class Enums
    {
        internal enum MainMenuOptions
        {
            ManageCategories,
            ManageProducts,
            Quit
        }

        internal enum CategoryMenu
        {
            AddCategory,
            DeleteCategory,
            UpdateCategory,
            ViewCategory,
            ViewAllCategories,
            GoBack
        }
        internal enum ProductMenu
        {
            AddProduct,
            DeleteProduct,
            UpdateProduct,
            ViewProduct,
            ViewAllProducts,
            GoBack
        }

    }
}
