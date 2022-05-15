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
        private HashSet<string> _userlist;

        public Community()
        { 
            
        }

        public Community(string name, string ownerLogin)
        {
            Name = name;
            OwnerLogin = ownerLogin;
        }

        public void JoinToCommunity(string login)
        {
            _userlist.Add(login);
        }
    }
}
