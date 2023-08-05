using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    
    public class SendMessage : ControllerBase
    {
        
        [HttpPost]
        public IActionResult Message(JObject payload)
        {
            message msg = new message();
            bool success = false;
            msg = JsonConvert.DeserializeObject<message>(payload.ToString());
            foreach (User user in Globals.db.root.users)
            {
                if (msg.username == user.user && msg.password == user.password)
                {
                    foreach (Conversation convo in user.conversations)
                    {
                        if ((convo.user1 == msg.username && convo.user2 == msg.friend) || (convo.user1 == msg.friend && convo.user2 == msg.username))
                        {
                            Message mess = new Message { content = msg.content, reciever = msg.friend, sender = msg.username };
                            convo.messages.Add(mess);
                            UpdateDB.Update(Globals.db);
                            success = true;
                        }
                    }
                }
            }

            return success ? Ok("Success") : Ok("Fail");
        }

    }
}
