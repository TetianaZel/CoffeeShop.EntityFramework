using CoffeeShop.EntityFramework.Controllers;
using CoffeeShop.EntityFramework.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EntityFramework.Services
{
    internal class ReportService
    {
        internal static void CreateMonthlyReport()
        {
            var orders = OrderController.GetOrders();

            var report = orders.GroupBy(x => new
            {
                x.CreatedDate.Month,
                x.CreatedDate.Year
            })
                .Select(grp => new MonthlyReportDTO
                {
                    Month = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(grp.Key.Month)}/{grp.Key.Year}",
                    TotalQuantity = grp.Sum(x => x.OrderProducts.Sum(x => x.Quantity)),
                    TotalPrice = grp.Sum(x => x.TotalPrice)
                }).ToList();
            UserInterface.ShowReportByMonth(report);
        }
    }
}
