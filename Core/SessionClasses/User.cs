using System;
using System.Collections.Generic;

namespace Core
{
    public class User
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Login { get; private set; }
        public Dictionary<string, string> Socials { get; private set; }

        public User(string username, string login)
        {
            Name = username;
            Login = login;
            Socials = new Dictionary<string, string>();
        }

        public void AddSocials(string network, string username)
        {
            Socials.Add(network, username);
        }

        public string GetSocials()
        {
            string mes = "";
            foreach (var u in Socials)
            {
                mes += $"{u.Key}: {u.Value};\n";
            }
            return mes;
        }

    }
}
