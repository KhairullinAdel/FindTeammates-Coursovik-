using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder_Core
{
    public class Community
    {
        public string Name { get; private set; }
        public string OwnerLogin { get; private set; }
        public int UsersCount { get; private set; }

        public Community(string name, User owner)
        {
            Name = name;
            OwnerLogin = owner.Email;
            UsersCount = 0;
            owner.JoinToCommunity(this);
        }

        public void PlayerJoined()
        {
            UsersCount++;
        }
    }
}
