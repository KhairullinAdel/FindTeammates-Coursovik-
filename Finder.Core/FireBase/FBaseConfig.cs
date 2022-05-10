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
    public class FBaseConfig
    {
        internal static IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "Oq74Wtm31h2KJQv4fqHgwIQTt7jhaODV4tDKc3eS",
            BasePath = "https://findteammateapplication-default-rtdb.firebaseio.com/"
        };

        internal static IFirebaseClient client = new FireSharp.FirebaseClient(config);

        #region User
        public static void UserSave(User user)
        {
            int id = GetUsers().Count();
            user.SetID(id);
            FirebaseResponse response = FBaseConfig.client.Update("Users/" + id, user);
            User obj = response.ResultAs<User>();
        }
        public static IEnumerable<User> GetUsers()
        {
            FirebaseResponse response = FBaseConfig.client.Get("Users/");
            List<User> obj = response.ResultAs<List<User>>();
            return obj;
        }
        public static User GetUser(int id)
        {
            var response = FBaseConfig.client.Get("Users/" + id);
            var obj = response.ResultAs<User>();
            return obj;
        }
        #endregion

        #region
        #endregion
    }

}
