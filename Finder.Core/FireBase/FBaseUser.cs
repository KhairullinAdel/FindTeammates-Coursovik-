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
    public class FBaseUser
    {
        public static void UserSave(User user)
        {
            int id = GetUsers().Count();
            FirebaseResponse response = FBaseConfig.client.Update("Users/" + id, user);
            User obj = response.ResultAs<User>();
        }
        public static IEnumerable<User> GetUsers()
        {
            FirebaseResponse response = FBaseConfig.client.Get("Users/");
            List<User> obj = response.ResultAs<List<User>>();
            return obj;
        }
        public static OutputUser GetUser(int id)
        {
            var response = FBaseConfig.client.Get("Users/" + id);
            var obj = response.ResultAs<OutputUser>();
            return obj;
        }
    }
}
