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
    }
}
