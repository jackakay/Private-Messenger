using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Friend : ControllerBase
    {

        

        [HttpPost]
        public IActionResult AddFriend(JObject payload)
        {
            Console.WriteLine(payload.ToString());
            Console.WriteLine("attempted to add friend");
            bool success = false;
            loginClass newlogin = new loginClass();
            newlogin = JsonConvert.DeserializeObject<loginClass>(payload.ToString());
            foreach (User user in Globals.db.users)
            {
                if (newlogin.username == user.user && newlogin.password == user.password)
                {
                    foreach (User friend in Globals.db.users)
                    {
                        if (newlogin.friend == friend.user)
                        {
                            friend.friends.Add(newlogin.username);
                            Console.WriteLine("made it");
                            user.friends.Add(friend.user);
                            Globals.db.conversations.Add(new Conversation { user1=newlogin.username, user2=friend.user, messages = new List<Message>() });
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
