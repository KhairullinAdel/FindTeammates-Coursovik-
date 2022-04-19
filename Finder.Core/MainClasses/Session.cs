using System;
using System.Collections.Generic;
using System.Text;

namespace Finder_Core
{
    public class Session
    {
        public int ID { get; private set; }
        public User SessionHost { get; private set; }
        public List<User> Players { get; private set; }
        public int PlayerMaxCount { get; private set; }
        private bool StatusOfActivity { get; set; }

        public Session(User host, int maxcount)
        {
            SessionHost = host;
            PlayerMaxCount = maxcount;
            Players = new List<User>();
            StatusOfActivity = true;
        }

        public void Connect(User player)
        {
            if (Players.Count < PlayerMaxCount &&
                StatusOfActivity == true)
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
                Players.Clear();
                SessionDisable();
            }
        }

        private void SessionDisable()
        {
            StatusOfActivity = false;
        }

        public override string ToString()
        {
            if (!StatusOfActivity)
            {
                return "Room is already Disabled";
            }
            else
            {
                string mes = $"Session host: {SessionHost.Name};\n" +
                             $"User max count: {PlayerMaxCount};\n" +
                             $"Players: ";

                foreach (var u in Players)
                {
                    mes += $"{u.Name}, ";
                }

                mes.Substring(mes.Length);

                return String.Concat(mes, $";\n\n");
            }

        }


    }
}
