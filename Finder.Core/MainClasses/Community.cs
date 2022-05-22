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
        public string OwnerTag { get; private set; }
        public int UsersCount { get; private set; }
        public List<Session> SessionList { get; private set; }


        public Community()
        {
            SessionList = new List<Session>();
        }
        public Community(string name, User owner)
        {
            Name = name;
            OwnerTag = owner.UserTag;
            UsersCount = 0;
            SessionList = new List<Session>();
            owner.JoinToCommunity(this);
        }

        public void PlayerJoined()
        {
            UsersCount++;
        }

        public void GetSessions()
        {

        }

        public void SessionCreaton()
        {

        }
    }
}
