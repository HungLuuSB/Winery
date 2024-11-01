using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Winery.Models;

namespace Winery.Services
{
    public static class BrandService
    {
        private static WineryEntities2 db = new WineryEntities2();

        public static List<Brand> GetAllBrands()
        {
            return db.Brand.ToList();
        }
    }
}