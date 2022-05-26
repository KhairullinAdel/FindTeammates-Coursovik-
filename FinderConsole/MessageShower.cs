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

        #region on the launch
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
                    Console.WriteLine("UnknownCommand\n");
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
            Console.WriteLine("Please, wait a few seconds...\n");
            Dictionary<string, User> userList = DataAccess.GetUsers();
            user = new User();

            Console.WriteLine("Enter your User tag");
            string tag = Console.ReadLine();

            while(!userList.ContainsKey(tag))
            {
                Console.WriteLine("\nThere is no user with this tag. Try again please");
                tag = Console.ReadLine();
            }

            Console.WriteLine("\nEnter the password");
            string pass = Console.ReadLine();

            while (userList[tag].Password != user.GetHash(pass))
            {
                Console.WriteLine("\nIncorrect password. Try again please");
                pass = Console.ReadLine();
            }

            return DataAccess.GetUser(tag);
        }

        #endregion
        #endregion
        #region body of the programm
        public static bool ChooseAfterAuth(User user)
        {
            PrintEnterTheCommand();
            Console.WriteLine("\n1) Show your active session\n" +
                              "2) Leave from active session\n" +
                              "3) Show communities that have been joined\n" +
                              "4) Show all of exsiting communities\n" +
                              "5) Open community page" +
                              "6) Log out");

            string command = Console.ReadLine();

            switch(command)
            {
                case "1":
                    CheckAnActiveSession(user);
                    return true;
                case "2":
                    LeaveFromActiveSession(user);
                    return true;
                case "3":
                    return true;
                case "4":
                    return true;
                case "5":
                    return true;
                case "6":
                    return true;
                default:
                    return false;
                
            }
        }

        public static void CheckAnActiveSession(User user)
        {
            if (user.ActiveSession != null)
            {
                Console.WriteLine($"You have one active session that " +
                    $"has been hosted by {user.ActiveSession}");
            }
            else
            {
                Console.WriteLine($"You have no one active session at the moment.");
            }
        }

        public static void LeaveFromActiveSession(User user)
        {
            if (user.ActiveSession != null)
            {
                user.LeaveFromSession();
                Console.WriteLine("You have successfully left the session");
            }
            else
            {
                Console.WriteLine("You cannot leave the session.\n" +
                                  "You are not a member of any session");
            }
        }
        #endregion
    }
}
