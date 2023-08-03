using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetFriendsController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetFriends(JObject payload)
        {
            bool loggedIn = false;
            loginClass newlogin = new loginClass();
            newlogin = JsonConvert.DeserializeObject<loginClass>(payload.ToString());
            foreach (User user in Globals.db.root.users)
            {
                if (newlogin.username == user.user && newlogin.password == user.password)
                {
                    string json = JsonConvert.SerializeObject(user.friends);
                    return Ok(json);
                    loggedIn = true;

                }

            }
            if(!loggedIn)
            {
                return Ok("Fail");
            }
            else
            {
                return Ok("");
            }
            
        }
    }
}
