using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Winery.Services
{
    public class CategoryUtilityService
    {
        public static string ParseItemNameIntoPNGFileName(string name)
        {
            string temp = name + ".png";
            return temp;
        }
    }
}