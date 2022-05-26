using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Finder_Core.FireBase;

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
            CommunityOfCreation = comm.Name;
            comm.SessionList.Add(this.SessionHost.UserTag);
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
                    Players.Add(player.UserTag);

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
            if (player.UserTag != SessionHost.UserTag)
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
            foreach(var p in Players)
            {
                var deleted = DataAccess.GetUser(p);
                deleted.UserActiveStatusSwitch();
                DataAccess.UserSave(deleted);
            }
            var comm = DataAccess.GetCommunity(this.CommunityOfCreation);
            comm.SessionList.Remove(this.SessionHost.UserTag);
            DataAccess.CommumitySave(comm, DataAccess.GetUser(comm.OwnerTag));
            DataAccess.SessionDelete(this);
        }


    }
}
