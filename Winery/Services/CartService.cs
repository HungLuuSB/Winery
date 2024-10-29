using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Winery.Models;

namespace Winery.Services
{
    public static class CartService
    {
        public static List<Product> Cart = new List<Product>();

        public static void LoadCartOfUser()
        {
            if (UserSessionService.IsUserLoggedIn())
            {
                Cart.Clear();
            }
        }
    }
}