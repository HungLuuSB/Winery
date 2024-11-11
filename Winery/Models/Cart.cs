using System;
using System.Collections.Generic;
using Winery.Services;
using System.Linq;
using System.Web;

namespace Winery.Models
{

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedTime { get; set; }
    }

    public class Cart
    {
        public List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items 
        {
            get { return items; }
        }
        public void AddToCart(Product product, int quantity = 1)
        {
            var item = items.FirstOrDefault(x => x.Product.ProductID == product.ProductID);
            if (item == null) 
            {
                items.Add(new CartItem() { Product = product, Quantity = quantity, AddedTime = DateTime.Now });
            }
            else
            {
                item.Quantity += quantity;
            }
        }
        public void RemoveFromCart(int id)
        {
            items.RemoveAll(x => x.Product.ProductID == id);
        }
        public void UpdateQuantity(int id, int quantity)
        {
            var item = items.FirstOrDefault(x => x.Product.ProductID == id);
            if (item != null)
            {
                item.Quantity = quantity;
            }
        }
        public double TotalQuantity()
        {
            return items.Sum(x => x.Quantity);
        }
        public double TotalMoney()
        {
            return items.Sum(x => x.Quantity * (double)(ProductUtilityService.IsProductOnSale(x.Product) == true ? x.Product.ProductSalePrice : x.Product.ProductPrice));
        }
        public void ClearCart()
        {
            items.Clear();
        }
    }
}