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


            switch (command)
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

            switch (command)
            {
                case "1":
                    Console.WriteLine("Please, enter your username in Telegram");
                    social = Console.ReadLine();
                    while (social == "")
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

            while (!userList.ContainsKey(tag))
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
                              "5) Open community page\n" +
                              "6) Log out");

            string command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    CheckAnActiveSession(user);
                    return true;
                case "2":
                    LeaveFromActiveSession(user);
                    return true;
                case "3":
                    ShowUsersCommunities(user);
                    return true;
                case "4":
                    ShowAllCommunities();
                    return true;
                case "5":
                    OpenCommunityPage(user);
                    return true;
                case "6":
                    return false;
                default:
                    Console.WriteLine("Unknown command");
                    return true;

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

        public static void ShowUsersCommunities(User user)
        {
            int i = 1;
            Console.WriteLine("Your communities:\n");
            foreach (var c in user.Communities)
            {
                Console.Write($"{i}) {c}\n");
                i++;
            }
            Console.WriteLine();
        }

        public static void ShowAllCommunities()
        {
            List<Community> allComm = DataAccess.GetCommunities();
            int i = 1;
            Console.WriteLine("All communities:\n");
            foreach (var c in allComm)
            {
                Console.Write($"{i}) {c.Name}\n");
                i++;
            }
            Console.WriteLine();
        }

        public static void OpenCommunityPage(User user)
        {
            bool trigger = true;
            string command = "";

            Console.WriteLine("Please, wait...\n");
            List<Community> allComm = DataAccess.GetCommunities();
            List<string> allCommNames = new List<string>();
            foreach (var comm in allComm)
            {
                allCommNames.Add(comm.Name);
            }
            Console.WriteLine("Enter the community name or" +
                " \"goback\" if you want to go back");
            while (trigger)
            {
                command = Console.ReadLine();
                if (allCommNames.Contains(command))
                {
                    trigger = false;
                    trigger = CommunityPageOpening(user, command);
                }
                else if (command == "goback")
                {
                    trigger = false;
                }
                else
                {
                    Console.WriteLine("\nThere is no commnity" +
                        " with this name, try again");

                }

            }

        }
        #endregion

        #region inside the community
        public static bool CommunityPageOpening(User user, string commName)
        {
            bool isJoined = false;
            bool trigger = true;
            string command = "";

            Community comm = DataAccess.GetCommunity(commName);
            if (user.Communities.Contains(commName))
            {
                isJoined = true;
            }

            Console.WriteLine($"\nCommunity: {comm.Name}\n" +
                              $"Community creator: {comm.OwnerTag}\n" +
                              $"You are joined: {isJoined}\n");
            while (trigger)
            {
                Console.WriteLine("1) Create a session\n" +
                                  "2) Join a session\n" +
                                  "3) Check active sessions\n" +
                                  "4) Joit a community\n" +
                                  "5) Go back\n");

                command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        CreateASession(user, comm);
                        break;
                    case "2":
                        JoinAsession(user, comm);
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        trigger = false;
                        break;
                    default:
                        Console.WriteLine("Unknown command\n");
                        break;
                }
            }
            return trigger;

        }

        public static void CreateASession(User user, Community comm)
        {
            string command = "";
            bool trigger = true;
            if (user.Communities.Contains(comm.Name))
            {
                if (user.ActiveSession == null)
                {
                    Console.WriteLine("For how many players you want " +
                        "to create a session?");
                    while (trigger)
                    {
                        command = Console.ReadLine();
                        try
                        {
                            if (Convert.ToInt32(command) <= 1)
                            {
                                Console.WriteLine("Please, choose another count\n");
                            }
                            else
                            {
                                Session sess = new Session(user,
                                    Convert.ToInt32(command), comm);
                                DataAccess.SessionSave(sess, comm, user);
                                trigger = false;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("unknown input\n");
                        }

                    }
                }
                else
                {
                    Console.WriteLine("You are in a session already\n");
                }
            }
            else
            {
                Console.WriteLine("You have to join to community before you " +
                    "can create a session\n");
            }
        } 
        public static void JoinAsession(User user, Community comm)
        {
            string command = "";
            if (user.ActiveSession == null)
            {
                Console.WriteLine("Enter the session ownerTag if " +
                    "you want to connect");
                command = Console.ReadLine();
                if (comm.SessionList.Contains(command))
                {
                    user.JoinToSession(DataAccess.GetSession(command));
                    Console.WriteLine("Successfuly joined");
                }
                else
                {
                    Console.WriteLine("There is no session that has" +
                        " been created by this user");
                }
            }
            else
            {
                Console.WriteLine("You are already in a session");
            }
        }
        #endregion
    }
}
