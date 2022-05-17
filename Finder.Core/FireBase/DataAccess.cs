using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;

namespace Finder_Core.FireBase
{
    public class DataAccess
    {
        #region User
        public static void UserSave(User user)
        {
            FirebaseResponse response = FBaseConfig.client.Update("Users/" + user.UserTag, user);
            User obj = response.ResultAs<User>();
        }
        public static Dictionary<string, User> GetUsers()
        {
            Dictionary<string, User> users;
            Dictionary<string, User> outgoingUsers = new Dictionary<string, User>();

            FirebaseResponse response = FBaseConfig.client.Get("Users/");
            string jsonText = response.Body;
            if (jsonText?.Length > 0)
            {
                users = JsonConvert.DeserializeObject<Dictionary<string, User>>(jsonText);
                foreach (var user in users)
                {
                    outgoingUsers.Add(user.Key, DataAccess.GetUser(user.Key));
                }
                return outgoingUsers;
            }
            return outgoingUsers;
        }
        public static User GetUser(string email)
        {
            var response = FBaseConfig.client.Get("Users/" + email);
            var obj = response.ResultAs<User>();
            return obj;
        }
        #endregion

        #region Communities
        public static void CommumitySave(Community community)
        {
            FirebaseResponse response = 
                FBaseConfig.client.Update("Communities/" + community.Name, community);
            Community obj = response.ResultAs<Community>();
        }

        public static Community GetCommunity(string name)
        {
            var response = FBaseConfig.client.Get("Communities/" + name);
            var obj = response.ResultAs<Community>();
            return obj;
        }

        public static Dictionary<string, Community> GetCommunities()
        {
            var response = FBaseConfig.client.Get("Communities/");
            Dictionary<string, Community> obj = 
                JsonConvert.DeserializeObject<Dictionary<string, Community>>
                (response.Body.ToString());
            return obj;
        }

        #endregion
    }
}
