using System;
using System.Collections.Generic;
using System.Text;

using Finder_Core;
using Finder_Core.FireBase;

namespace FinderConsole
{
    internal class MessageShower
    {
        public static void PrintEnterTheCommand()
        {
            Console.WriteLine("Please, enter the command number");
        }

        public static User DoFirstLaunch(User user)
        {
            Console.WriteLine("1) Registration\n" +
                              "2) Authorisation");

            var command = Console.ReadLine();
            

            switch(command)
            {
                case "1":
                    user = RegistrateUser(user);
                    break;
                case "2":
                    user = AuthoriseUser(user);
                    break;
                default:
                    Console.WriteLine("UnknownCommand");
                    break;

            }
            return user;
        }

        #region reg
        public static User RegistrateUser(User user)
        {
            Console.WriteLine("Enter your nickname");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your tag (it will be used " +
                "for authorisation in future)");
            string tag = Console.ReadLine();

            Console.WriteLine("Enter the pasword");
            string password = Console.ReadLine();

            if (name == "" || tag == "" || password == "")
            {
                return null;
            }
            else
            {
                user = new User(name, tag, password);
            }
            SocialAdd(user);
            return user;
        }

        public static void SocialAdd(User user)
        {
            Console.WriteLine("Which social are you want to add to your profile?");
            Console.WriteLine("1) Telegram\n" +
                              "2) Discord");

            var command = Console.ReadLine();
            var social = "";

            switch(command)
            {
                case "1":
                    Console.WriteLine("Please, enter your username in Telegram");
                    social = Console.ReadLine();
                    while(social == "")
                    {
                        Console.WriteLine("Please, enter your username in Telegram");
                        social = Console.ReadLine();
                    }
                    user.AddSocials("Telegram", social);
                    break;

                case "2":
                    Console.WriteLine("Please, enter your username in Discord");
                    social = Console.ReadLine();
                    while (social == "")
                    {
                        Console.WriteLine("Please, enter your username in Telegram");
                        social = Console.ReadLine();
                    }
                    user.AddSocials("Discord", social);
                    break;
            }
                                            
        }
        #endregion

        #region auth
        public static User AuthoriseUser(User user)
        {
            Dictionary<string, User> userList = DataAccess.GetUsers();
            user = new User();

            Console.WriteLine("Enter your User tag");
            string tag = Console.ReadLine();

            while(!userList.ContainsKey(tag))
            {
                Console.WriteLine("There is no user with this tag. Try again please");
                tag = Console.ReadLine();
            }

            Console.WriteLine("Enter the password");
            string pass = Console.ReadLine();

            while (userList[tag].Password != user.GetHash(pass))
            {
                Console.WriteLine("Incorrect password. Try again please");
                pass = Console.ReadLine();
            }

            return DataAccess.GetUser(tag);
        }

        #endregion

    }
}
