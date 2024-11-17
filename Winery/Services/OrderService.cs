using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winery.Models;

namespace Winery.Services
{
    public static class OrderService
    {
        private static WineryEntities2 db = new WineryEntities2();

        public static List<Order> GetOrders()
        {
            return db.Order.ToList();
        }
        public static List<Order> GetOrdersFromUser(int id)
        {
            return db.Order.Where(x => x.UserID == id).ToList();
        }
        public static double GetProfit()
        {
            double sum = 0;
            var orders = db.Order.ToList();
            foreach (var order in orders)
            {
                var orderDetails = db.OrderDetails.Where(x => x.OrderID == order.OrderID).ToList();
                foreach (var item in orderDetails)
                {
                    sum += item.Quantity * item.UnitPrice;
                }
            }
            return sum;
        }
    }
}
