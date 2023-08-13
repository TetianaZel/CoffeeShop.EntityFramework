using CoffeeShop.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EntityFramework.Controllers
{
    internal class OrderController
    {
        internal static void AddOrder(List<OrderProduct> orders)
        {
            using var db = new ProductContext();
            db.AddRange(orders);
            db.SaveChanges();
        }
        internal static List<Order> GetOrders()
        {
            using var db = new ProductContext();

            var ordersList = db.Orders
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .ThenInclude(p => p.Category)
                .ToList();
            
            return ordersList;
        }

    }
}
