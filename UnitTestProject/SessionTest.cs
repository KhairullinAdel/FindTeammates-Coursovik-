using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Finder_Core;

namespace UnitTestProject
{
    [TestClass]
    public class SessionTest
    {
        Session sess;
        User host;

        //TestClass constructor
        public SessionTest()
        {
            host = new User("Bob", "SomeAdress", "123");

        }

        [TestMethod]
        public void SessionCreationSuccess()
        {
            Assert.IsNotNull(sess);
        }

        [TestMethod]
        public void SessionConectSuccess()
        {
            sess.Connect(new User("joe", "joe", "123"));
            Assert.IsNotNull(sess.Players);
        }

        [TestMethod]
        public void LeavingFromSessionTesting()
        {
            User connectedUser = new User("joe", "joe", "123");
            sess.Connect(connectedUser);
            sess.Leave(connectedUser);

            Assert.AreEqual(sess.Players.Count, 0);
        }

        [TestMethod]
        public void HostIsLeavingFromSessionTest()
        {
            sess.Leave(host);

            Assert.AreEqual(sess.ToString(), "Room is already Disabled");
        }

    }
}
