using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPFirst.Data
{
    internal class CurrentUser
    {
        public static User currentUser;

        public static bool IsAdmin => currentUser?.Role?.Title == "admin";
        public static bool IsUser => currentUser?.Role?.Title == "user";

        public static bool CanManageItems => IsAdmin;
        public static bool CanManageUsers => IsAdmin;
        public static bool CanDeleteFromBasket => !IsAdmin;
        public static bool CanAddToBasket => !IsAdmin;
        public static bool CanBuy => !IsAdmin;
    }
}
