using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finder_Core;

namespace UnitTestProject
{
    [TestClass]
    public class SessionTest
    {
        User host;
        Community comm;

        //TestClass constructor
        public SessionTest()
        {
            host = new User("Bob", "SomeAdress", "123");
            comm = new Community("WarFolomeus", host);
        }

        [TestMethod]
        public void SessionCreationTest()
        {
            Session testSession = new Session(host, 3, comm);
            Assert.IsNotNull(testSession);
        }
    }
}
