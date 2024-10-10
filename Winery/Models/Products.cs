using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Winery.Models
{
    public class Products
    {
        #region Properties
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public string ProductCapacity { get; set; }
        #endregion


    }
}