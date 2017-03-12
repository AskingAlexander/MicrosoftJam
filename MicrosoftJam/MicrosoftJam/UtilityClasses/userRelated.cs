using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MicrosoftJam.UtilityClasses
{
    class UserRelated
    {
        public static string userName;

        internal static bool IsLoggedIn()
        {
            string tempUser = DependencyService.Get<ISaveAndLoad>().LoadText("user.txt"); ;

            if (tempUser.Length > 0)
            {
                userName = tempUser;
                return true;
            }

            return false;
        }
    }
}
