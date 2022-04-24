using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Finder_Core
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int Level { get; private set; }
        public int XP { get; private set; }
        public Dictionary<string, string> Socials { get; private set; }

        public User()
        {

        }
        public User(string username, string email)
        {
            Name = username;
            Email = email;
            Level = 0;
            Socials = new Dictionary<string, string>();
        }

        public void AddSocials(string network, string username)
        {
            Socials.Add(network, username);
        }

        public Dictionary<string, string> GetSocials()
        {
            return this.Socials;
        }
    }
}
