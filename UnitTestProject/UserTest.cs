using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Finder_Core;

namespace UnitTestProject
{
    [TestClass]
    public class UserTest
    {
        User user;

        //TestClass constructor
        public UserTest()
        {
            user = new User("Bob", "SomeAdress", "123");
        }

        [TestMethod]
        public void UserCreationSuccess()
        {
            Assert.IsNotNull(this.user);
        }

        [TestMethod]
        public void UserSocialsAdditionSuccess()
        {
            user.AddSocials("Discord", "ObjectiveGood#9925");

            Dictionary<string, string> tempdict = 
                new Dictionary<string, string>();
            tempdict.Add("Discord", "ObjectiveGood#9925");

            CollectionAssert.AreEqual(user.GetSocials(), tempdict);
        }
    }
}
