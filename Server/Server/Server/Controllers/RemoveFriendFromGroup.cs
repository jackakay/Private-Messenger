using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoveFriendFromGroup : Controller
    {
        [HttpPost]
        public IActionResult SendMessage(JObject payload)
        {
            bool success = false;
            string json = "";
            if (payload != null)
            {
                getgroup login = new getgroup();
                login = JsonConvert.DeserializeObject<getgroup>(payload.ToString());
                foreach(Groups group in Globals.db.groups)
                {
                    if(group.name == login.groupName)
                    {
                        group.users.Remove(login.message);
                        UpdateDB.Update(Globals.db);
                        success = true;
                    }
                }
            }

            return success ? Ok("Success") : Ok("Fail");
        }
    }
}
