using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Winery.Models;

namespace Winery.Services
{
    public static class PermissionService
    {
        private static WineryEntities2 db = new WineryEntities2();

        public static bool UserHasPermission(User _currentUser, int permissionID)
        {
            if (UserSessionService.IsUserLoggedIn() == false)
                return false;
            var per = db.Permission.Where(x => x.PermissionId == permissionID).FirstOrDefault();
            if (per == null)
                return false;
            var userPer = _currentUser.UserPermission.Where(x => x.UserId == _currentUser.UserID).FirstOrDefault();
            if (userPer == null)
                return false;
            //Debug.WriteLine($"{userPer.PermissionId} - {per.PermissionId}");
            if (userPer.PermissionId > permissionID)
                return false;
            return true;
        }
        public static bool UserHasPermission(User _currentUser, string permissionName)
        {
            if (UserSessionService.IsUserLoggedIn() == false)
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
    }
}