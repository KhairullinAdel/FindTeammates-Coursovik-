using System;
using Finder_Core;

namespace DebugCosole
{
    public class Program
    {
        static void Main(string[] args)
        {
            User user = new User("bob", "NoLogin");
            User user2 = new User("bob", "NoLogin");
            User user3 = new User("Phil", "NoLogin");

            Session sess = new Session(user, 6);

            sess.Connect(user2);
            sess.Connect(user3);

            user.AddSocials("Discord", "#1234 Adolfus");
            user.AddSocials("Telegram", "@objectivegood");

            Console.WriteLine(sess);

            sess.Leave(user);
            Console.WriteLine(sess);

            //Console.WriteLine(user.GetSocials());

            
        }
    }
}
