using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Session
    {
        public int ID { get; private set; }
        public User SessionHost{ get; private set; }
        public List<User> Players { get; private set; }
        public int PlayerMaxCount { get; private set; }

        public Session(User host, int maxcount)
        {
            SessionHost = host;
            PlayerMaxCount = maxcount;
            Players = new List<User>();
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

        public override string ToString()
        {
            string mes = $"Session host: {SessionHost.Name};\n" +
                   $"User max count: {PlayerMaxCount};\n" +
                   $"Players: ";

            foreach (var u in Players)
            {
                mes += $"{u.Name}, ";
            }

            mes.Substring(mes.Length);

            return String.Concat(mes, ";");
        }

        
    }
}
