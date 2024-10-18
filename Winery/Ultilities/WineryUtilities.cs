using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Winery.Models;

namespace Winery.Ultilities
{
    public static class WineryUtilities
    {
        private static WineryEntities2 db = new WineryEntities2();
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
        public static int? GetUserIDFromName(string username) 
        {
            var user = db.User.Where(x => x.Username.Equals(username)).FirstOrDefault();
            if (user != null)
            {
                return user.UserID;
            }
            return null;
        }
    }
}