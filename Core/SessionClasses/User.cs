using System;
using System.Collections.Generic;

namespace Core
{
    public class User
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Login { get; private set; }
        public int Level { get; private set; }
        public int XP { get; private set; }
        public Dictionary<string, string> Socials { get; private set; }

        public User(string username, string login)
        {
            Name = username;
            Login = login;
            Level = 0;
            Socials = new Dictionary<string, string>();
        }

        public void AddSocials(string network, string username)
        {
            Socials.Add(network, username);
        }
        public override string ToString()
        { 
            return $"Username: {Name}\n" +
                   $"Current Level: {Level}\n" +
                   $"Current XP: {Level}\n"; ;
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
