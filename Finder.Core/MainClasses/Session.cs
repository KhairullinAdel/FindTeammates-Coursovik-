using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Finder_Core
{
    public class Session
    {
        [Required()]
        public User SessionHost { get; private set; }
        [Required()]
        public List<User> Players { get; private set; }
        [Required()]
        public int PlayerMaxCount { get; private set; }
        //private bool StatusOfActivity { get; set; }
        [Required()]
        public string CommunityOfCreation { get; private set; }

        public Session()
        {

        }
        public Session(User host, int maxcount, Community comm)
        {
            SessionHost = host;
            PlayerMaxCount = maxcount;
            Players = new List<User>();
            Players.Add(SessionHost);
            CommunityOfCreation = comm.Name;
            comm.SessionList.Add(this);
        }

        public void Connect(User player)
        {
            if (Players.Count < PlayerMaxCount)
            {
                Players.Add(player);
            }
            else
            {
                throw new Exception("Room is already full");
            }
        }

        public void Leave(User player)
        {
            if (player != SessionHost)
            {
                Players.Remove(player);
            }
            else
            {
                SessionDisable();
            }
        }

        private void SessionDisable()
        {
            Players.Clear();
        }


    }
}
