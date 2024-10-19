using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Winery.Models;

namespace Winery.Ultilities
{
    public static class WineryUtilities
    {
        private static WineryEntities2 db = new WineryEntities2();
        private static User _currentUser = null;
        public static User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
            }
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
        public static bool IsUserLoggedIn()
        {
            return _currentUser != null;
        }
        public static bool UserHasPermission(int permissionID) { 
            if (IsUserLoggedIn() == false)
                return false;
            var per = db.Permission.Where(x => x.PermissionId == permissionID).FirstOrDefault();
            if (per == null)
                return false;
            var userPer = _currentUser.UserPermission.Where(x => x.UserId == _currentUser.UserID).FirstOrDefault();
            if (userPer == null)
                return false;
            //Debug.WriteLine($"{userPer.PermissionId} - {per.PermissionId}");
            if (userPer.PermissionId > per.PermissionId)
                return false;
            return true;
        }
        public static bool UserHasPermission(string permissionName)
        {
            if (IsUserLoggedIn() == false)
                return false;
            var per = db.Permission.Where(x => x.PermissionName == permissionName).FirstOrDefault();
            if (per == null)
                return false;
            var userPer = _currentUser.UserPermission.Where(x => x.UserId == _currentUser.UserID).FirstOrDefault();
            if (userPer == null)
                return false;
            //Debug.WriteLine($"{userPer.PermissionId} - {per.PermissionId}");
            if (userPer.PermissionId > per.PermissionId)
                return false;
            return true;
        }
        public static bool TestPermission(int permissionId)
        {
            return db.UserPermission
                 .Any(up => up.UserId == CurrentUser.UserID &&
                            up.Permission.PermissionId == permissionId);
        }
    }
}