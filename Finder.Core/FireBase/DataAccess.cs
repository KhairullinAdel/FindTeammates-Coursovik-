using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Finder_Core.FireBase
{
    public class DataAccess
    {
        #region User
        public static void UserSave(User user)
        {
            FirebaseResponse response = FBaseConfig.client.Update("Users/" + user.Email, user);
            User obj = response.ResultAs<User>();
        }
        public static IEnumerable<User> GetUsers()
        {
            FirebaseResponse response = FBaseConfig.client.Get("Users/");
            List<User> obj = response.ResultAs<List<User>>();
            return obj;
        }
        public static User GetUser(string email)
        {
            var response = FBaseConfig.client.Get("Users/" + email);
            var obj = response.ResultAs<User>();
            return obj;
        }
        #endregion

        #region
        #endregion
    }
}
