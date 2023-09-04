using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendGroupMessage : Controller
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
                        Message msg = new Message();
                        msg.sender = login.username;
                        msg.content = login.message;
                        msg.reciever = "";
                        group.messages.Add(msg);
                        success = true;
                        UpdateDB.Update(Globals.db);
                    }
                }
            }

            return success ? Ok("Success") : Ok("Fail");
        }
    }
}
