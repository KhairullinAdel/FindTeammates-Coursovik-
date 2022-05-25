using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finder_Core;
using Finder_Core.FireBase;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public User loggedUser { get; private set; }
        public Community usedComm { get; private set; }
        [HttpGet]
        public bool Authorise(string userTag, string password)
        {
            try
            {
                var user = DataAccess.GetUser(userTag);
                if (user.Password == user.GetHash(password))
                {
                    loggedUser = user;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        [HttpPost("commCreate")]
        public IActionResult CreateComm(string userTag, string password, string name)
        {
            this.Authorise(userTag, password);

            if(loggedUser != null)
            {
                Community comm = new Community(name, loggedUser);
                DataAccess.CommumitySave(comm, loggedUser);
                return Content($"Community {name} has been created. \n" +
                    $"Community creator: {loggedUser.Name}");
            }
            else
            {
                return Content("Invalid user data");
            }
            
        }

        [HttpPost("sesionInAcommCreate")]
        public IActionResult CreateSession(string userTag, string password, string comm, int count)
        {
            this.Authorise(userTag, password);
            usedComm = DataAccess.GetCommunity(comm);

            if (loggedUser != null)
            {
                try
                {
                    Session sess = new Session(loggedUser, count, usedComm);
                    DataAccess.SessionSave(sess, usedComm, loggedUser);
                    return Content($"Session in {usedComm.Name} has been " +
                        $"created by a {loggedUser.Name} " +
                        $"for {sess.PlayerMaxCount} players");
                }
                catch
                {
                    return Content("You are already in a session");
                } 
            }
            else
            {
                return Content("Invalid user data");
            }
        }
    }
}
