using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadMessages : ControllerBase
    {
        

        [HttpPost]
        public IActionResult GetMessages(JObject payload)
        {
            bool success = false;
            loginClass newlogin = new loginClass();
            
            newlogin = JsonConvert.DeserializeObject<loginClass>(payload.ToString());
            foreach (User user in Globals.db.users)
            {
                
                if (newlogin.username == user.user && newlogin.password == user.password)
                {
                    foreach (Conversation convo in Globals.db.conversations)
                    {
                        if ((convo.user1 == newlogin.friend && convo.user2 == user.user) || (convo.user2 == newlogin.friend && convo.user1==user.user))
                        {
                            string json = JsonConvert.SerializeObject(convo);
                            success = true;
                            return Ok(json);
                            
                        }
                    }

                }
            }
            return success ? Ok("Success") : Ok("Fail");

        }
    }
}
