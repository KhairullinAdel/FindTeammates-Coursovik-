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
        public List<string> Players { get; private set; }
        [Required()]
        public int PlayerMaxCount { get; private set; }
        [Required()]
        public string CommunityOfCreation { get; private set; }

        public Session()
        {

        }
        public Session(User host, int maxcount, Community comm)
        {
            SessionHost = host;
            PlayerMaxCount = maxcount;
            Players = new List<string>();
            Players.Add(SessionHost.Name);
            CommunityOfCreation = comm.Name;
            comm.SessionList.Add(this);
            try
            {
                host.JoinToSession(this);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Connect(User player)
        {
            if (Players.Count < PlayerMaxCount)
            {
                if (player.ActiveSession == null)
                {
                    Players.Add(player.Name);
                }
                else
                {
                    throw new Exception("You are already in a session");
                }
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
                Players.Remove(player.Name);
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
