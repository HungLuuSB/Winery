using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Winery.Models;

namespace Winery.Services
{
    public static class UserSessionService
    {
        private static User _currentUser = null;
        public static User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
            }
        }

        public static bool IsUserLoggedIn()
        {
            return _currentUser != null;
        }

        public static void Logout()
        {
            if (_currentUser != null) {
                _currentUser = null;
            }
        }
    }
}