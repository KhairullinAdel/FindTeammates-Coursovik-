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
        public static User GetUser(string userTag)
        {
            var response = FBaseConfig.client.Get("Users/" + userTag);
            var obj = response.ResultAs<User>();
            return obj;
        }
        #endregion

        #region Communities
        public static void CommumitySave(Community community, User user)
        {
            FirebaseResponse response = 
                FBaseConfig.client.Update("Communities/" + community.Name, community);
            Community obj = response.ResultAs<Community>();

            UserSave(user);
        }

        public static Community GetCommunity(string name)
        {
            var response = FBaseConfig.client.Get("Communities/" + name);
            var obj = response.ResultAs<Community>();
            return obj;
        }

        public static List<Community> GetCommunities()
        {
            var response = FBaseConfig.client.Get("Communities/");
            Dictionary<string, Community> obj = 
                JsonConvert.DeserializeObject<Dictionary<string, Community>>
                (response.Body.ToString());

            List<Community> returned = new List<Community>();

            foreach (var comm in obj)
            {
                returned.Add(GetCommunity(comm.Key.ToString()));
            }
            return returned;
        }

        public static List<Community> GetCommByUser(User u)
        {
            List<Community> returned = new List<Community>();

            foreach (var comm in u.Communities)
            {
                returned.Add(GetCommunity(comm));
            }

            return returned;
        }

        #endregion

        #region Sessions
        public static List<Session> GetSessByComm(Community c)
        {
            List<Session> returned = new List<Session>();

            foreach (var comm in c.SessionList)
            {
                returned.Add(comm);
            }

            return returned;
        }
        #endregion
    }
}
