using System.Collections.Generic;

using Finder_Core;

namespace Api
{
    public class SessionModel
    {
        public string SessionHost { get; private set; }
        public List<string> Players { get; private set; }
        public int PlayerMaxCount { get; private set; }
        public string CommunityOfCreation { get; private set; }

        public SessionModel(Session fullSession)
        {
            this.SessionHost = fullSession.SessionHost.UserTag;
            this.Players = fullSession.Players;
            this.PlayerMaxCount = fullSession.PlayerMaxCount;
            this.CommunityOfCreation = fullSession.CommunityOfCreation;
        }
    }
}
