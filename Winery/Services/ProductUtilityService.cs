using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Winery.Models;

namespace Winery.Services
{
    public static class ProductUtilityService
    {
        private static WineryEntities2 db = new WineryEntities2();
        public static List<string> SortOptions = new List<string>()
        {
            "RELEVANCE",
            "PRICE-ASC",
            "PRICE-DESC",
            "NAME-ASC",
            "NAME-DESC"
        };
        public static string SortOption { get; set; } = SortOptions[0];
        public static bool IsSortOptionExists(string option)
        {
            if (string.IsNullOrWhiteSpace(option))
                return false;
            else
                return SortOptions.Contains(option);
        }
        public static string ParseItemNameIntoPNGFileName(string name)
        {
            string temp = name.ToLower().Replace(' ', '_') + ".png";
            return temp;
        }
        public static int? GetAgingYearFromNow(int? year)
        {
            if (year == null)
                return 0;
            return year;
        }
        public static IEnumerable<Product> GetRandomItems(int count)
        {
            if (count > db.Product.Count())
                count = db.Product.Count();
            return db.Product.OrderBy(x => Guid.NewGuid()).Take(count).ToList();
        }
        public static bool IsProductOnSale(Product product)
        {
            return product.ProductOnSale == true;
        }
        public static IEnumerable<Product> GetOnSaleProducts()
        {
            return db.Product.Where(x => x.ProductOnSale == true).ToList();
        }
    }
}