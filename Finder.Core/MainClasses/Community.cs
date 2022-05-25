using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Finder_Core.FireBase;

namespace Finder_Core
{
    public class Community
    {
        public string Name { get; private set; }
        public string OwnerTag { get; private set; }
        public int UsersCount { get; private set; }
        public List<string> SessionList { get; private set; }

        public Community()
        {
            SessionList = new List<string>();
        }
        public Community(string name, User owner)
        {
            Name = name;
            OwnerTag = owner.UserTag;
            UsersCount = 0;
            SessionList = new List<string>();
            owner.JoinToCommunity(this);
        }

        public void PlayerJoined()
        {
            UsersCount++;
        }
    }
}
