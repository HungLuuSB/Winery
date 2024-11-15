using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Winery.Models
{
    public class OrderModel
    {
        public DateTime OrderDate { get; set; }
        public int UserID { get; set; }
        public float Total { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Address { get; set; }
    }
}