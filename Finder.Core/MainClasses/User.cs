﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

using Finder_Core.FireBase;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Finder_Core
{
    public class User
    {
        [Required()]
        public string UserTag { get; private set; }
        [Required()]
        public string Name { get; private set; }
        [Required()]
        public string Password { get; private set; }
        public int Level { get; private set; }
        public int XP { get; private set; }
        public Dictionary<string, string> Socials { get; private set; }
        public List<string> Communities { get; private set; }
        //public Session ActiveSession{ get; private set; }
        public string ActiveSession{ get; private set; }

        public User()
        {
            Communities = new List<string>();
        }

        public User(string username, string userTag, string password)
        {
            Name = username;
            UserTag = userTag;
            Password = this.GetHash(password);
            Level = 0;
            Socials = new Dictionary<string, string>();
            Communities = new List<string>();
            ActiveSession = null;
        }

        public void AddSocials(string network, string username)
        {
            Socials.Add(network, username);
        }

        public Dictionary<string, string> GetSocials()
        {
            return this.Socials;
        }

        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
        public void JoinToCommunity(Community community)
        {
            if (!Communities.Contains(community.Name))
            {
                Communities.Add(community.Name);
                community.PlayerJoined();
            }
            DataAccess.UserSave(this);
            DataAccess.CommumitySave(community, 
                DataAccess.GetUser(community.OwnerTag));
        }

        public void JoinToSession(Session session)
        {
            Community comm = DataAccess.GetCommunity(session.CommunityOfCreation);
            try
            {
                session.Connect(this);
                this.ActiveSession = session.SessionHost.UserTag;
                DataAccess.SessionSave(session, comm, this);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void LeaveFromSession()
        {
            var session = DataAccess.GetSession(ActiveSession);
            var comm = DataAccess.GetCommunity(session.CommunityOfCreation);
            session.Leave(this);
            this.ActiveSession = null;
            DataAccess.SessionSave(session, comm, this);
        }
    }
}
