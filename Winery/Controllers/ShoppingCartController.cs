using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winery.Models;

namespace Winery.Controllers
{
    public class ShoppingCartController : Controller
    {
        private WineryEntities2 db = new WineryEntities2();
        // GET: ShoppingCart

        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult ShowCart()
        {
            if (Session["Cart"] == null)
            {
                return View("ShowCart");
            }
            Cart _cart = Session["Cart"] as Cart;
            return View(_cart);
        }
        public ActionResult AddToCart(int id)
        {  
            var _pro = db.Product.SingleOrDefault(s => s.ProductID == id);
            if (_pro != null)
            {
                GetCart().AddToCart(_pro);
            }
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        
        public ActionResult UpdateCartQuantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(Request.Form["idPro"]);
            int _quantity = int.Parse(Request.Form["carQuantity"]);
            cart.UpdateQuantity(id_pro, _quantity);

            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.RemoveFromCart(id);

            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        
    }
}