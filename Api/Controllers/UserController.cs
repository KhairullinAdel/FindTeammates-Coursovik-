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
        [HttpPut("{user}, {comm}")]
        public void JoinToComm(string u, string c)
        {
            var comm = DataAccess.GetCommunity(c);
            var user = DataAccess.GetUser(u);

            user.JoinToCommunity(comm);
        }
    }
}
