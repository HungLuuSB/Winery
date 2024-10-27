using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Winery.Models;

namespace Winery.Services
{
    public static class CategoryUtilityService
    {
        private static WineryEntities2 db = new WineryEntities2();
        public static bool IsCategoryExists(int id)
        {
            var category = GetCategoryByID(id);
            return category == null;
        }
        public static Category GetCategoryByID(int id)
        {
            var category = db.Category.Where(x => x.CategoryID == id).First();
            return category;
        }
        public static string ParseItemNameIntoPNGFileName(string name)
        {
            string temp = name + ".png";
            return temp;
        }
    }
}