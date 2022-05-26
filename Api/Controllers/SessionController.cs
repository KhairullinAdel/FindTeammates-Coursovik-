using Microsoft.AspNetCore.Mvc;

using Finder_Core.FireBase;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : Controller
    {
        [HttpGet]
        public SessionModel GetSession(string ownerTag)
        {
            var sessions = DataAccess.GetActiveSesionHosts();
            if (sessions.Contains(ownerTag))
            {
                var fullVersion = DataAccess.GetSession(ownerTag);
                return new SessionModel(fullVersion);
            }
            else
            {
                return null;
            }
        }
    }
}
