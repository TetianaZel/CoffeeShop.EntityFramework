using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EntityFramework.Models.DTOs
{
    internal class MonthlyReportDTO
    {
        public string Month { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalQuantity { get; set; }
    }
}
