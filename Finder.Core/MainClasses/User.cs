using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

using Finder_Core.FireBase;
using System.Security.Cryptography;
using System.Text;

namespace Finder_Core
{
    public class User
    {
        public string Name { get; private set; }
        public string UserTag { get; private set; }
        public string Password { get; private set; }
        public int Level { get; private set; }
        public int XP { get; private set; }
        public Dictionary<string, string> Socials { get; private set; }
        public List<string> Communities { get; private set; }

        public User()
        {

        }

        public User(string username, string email, string password)
        {
            Name = username;
            UserTag = email;
            Password = this.GetHash(password);
            Level = 0;
            Socials = new Dictionary<string, string>();
            Communities = new List<string>();
        }

        public void AddSocials(string network, string username)
        {
            Socials.Add(network, username);
        }

        public Dictionary<string, string> GetSocials()
        {
            return this.Socials;
        }

        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        public void JoinToCommunity(Community community)
        {
            if (!Communities.Contains(community.Name))
            {
                Communities.Add(community.Name);
                community.PlayerJoined();
            }
        }

        public List<Community> GetCommunityList()
        {
            List<Community> returned = new List<Community>();

            foreach (var comm in this.Communities)
            {
                returned.Add(DataAccess.GetCommunity(comm));
            }

            return returned;
        }

    }
}
