using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Winery.Models;
using Winery.Services;

namespace Winery.Services
{
    public static class CartService
    {
        private static List<Order> _orders = new List<Order>();
        public static List<Order> Orders
        {
            get
            {
                return _orders;
            }
        }
    }
}