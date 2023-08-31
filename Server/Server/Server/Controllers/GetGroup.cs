using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetGroup : Controller
    {
        [HttpPost]
        public IActionResult getGroup(JObject payload) 
        {
            bool success = false;
            string json = "";
            if(payload != null)
            {
                getgroup login = new getgroup();
                login = JsonConvert.DeserializeObject<getgroup>(payload.ToString());
                foreach(Groups group in Globals.db.groups)
                {
                    if (group.users.Contains(login.username)) 
                    {
                        json = JsonConvert.SerializeObject(group);
                        success = true;
                    }
                }
            }
            return success ? Ok(json) : Ok("Fail");
        }
    }
}
