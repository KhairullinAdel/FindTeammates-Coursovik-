using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Finder_Core;
using Finder_Core.FireBase;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityController : ControllerBase
    {
        [HttpGet]
        public List<Community> Get()
        {
            return DataAccess.GetCommunities();
        }
    }
}
