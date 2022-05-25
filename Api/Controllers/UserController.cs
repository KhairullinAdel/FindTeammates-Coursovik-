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

        [HttpGet()]
        public string Authorise(string userTag, string password)
        {
            try
            {
                var user = DataAccess.GetUser(userTag);
                if (user.Password == user.GetHash(password))
                {
                    loggedUser = user;
                    return "Success";
                }
                else
                {
                    return "Incorrect";
                }
            }
            catch
            {
                return "There is no user with this tag";
            }
        }     
    }
}
