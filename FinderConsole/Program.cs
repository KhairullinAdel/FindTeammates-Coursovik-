using System;
using Finder_Core;

namespace FinderConsole
{
    class Program
    {
        private static User user = null;
        static bool trigger = true;
        static void Main(string[] args)
        {
            MessageShower.PrintEnterTheCommand();
            while (trigger == true)
            {
                user = MessageShower.DoFirstLaunch(user);
                if (user != null)
                {
                    trigger = false;
                }
            }
            Console.WriteLine("\nAuthorisation is success");

            trigger = true;

            while (trigger == true)
            {
                trigger = MessageShower.ChooseAfterAuth(user);
            }

        }
    }
}
