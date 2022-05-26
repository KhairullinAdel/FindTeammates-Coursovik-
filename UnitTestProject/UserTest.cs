using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void UserGetSocialsTesting()
        {
            user.AddSocials("Discord", "ObjectiveGood#9925");

            Dictionary<string, string> tempdict = 
                new Dictionary<string, string>();
            tempdict.Add("Discord", "ObjectiveGood#9925");

            CollectionAssert.AreEqual(user.GetSocials(), tempdict);
        }

        [TestMethod]
        public void UserAddToSocialsTesting()
        {
            user.AddSocials("Telegram", "abcdefg");
            user.AddSocials("Discord", "@ABCDEFG");

            Assert.AreEqual(user.Socials.Keys.Count, 2);
        }

        [TestMethod]
        public void UserPasswordHashingTesting()
        {
            string name = "DefaultName";
            string tag = "defaulttag";
            string pass = "defaultOPass";

            user = new User(name, tag, pass);

            Assert.AreNotEqual(user.Password, pass);
        }
    }
}
