using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Winery.Ultilities
{
    public static class WineryUtilities
    {
        public static string ParseItemNameIntoPNGFileName(string name)
        {
            string temp = name.ToLower().Replace(' ', '_') + ".png";
            return temp;
        }
        public static int? GetAgingYearFromNow(int? year)
        {
            if (year == null)
                return 0;
            return DateTime.Now.Year - year;
        }
    }
}