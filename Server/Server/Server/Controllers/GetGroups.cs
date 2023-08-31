using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetGroups : Controller
    {
        [HttpPost]
        public IActionResult getGroups(JObject payload)
        {
            bool success = false;
            List<Groups> allGroups = new List<Groups>();
            getgroup login = new getgroup();
            login = JsonConvert.DeserializeObject<getgroup>(payload.ToString());
            foreach (Groups groups in Globals.db.groups)
            {
                if (groups.users.Contains(login.username))
                {
                    allGroups.Add(groups);
                    success = true;
                }
            }
            string json = JsonConvert.SerializeObject(allGroups);
            Console.WriteLine(json);
            return success ? Ok(json) : Ok("Fail");
        }
    }
}
 