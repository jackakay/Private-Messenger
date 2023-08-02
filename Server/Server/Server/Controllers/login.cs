using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class login : ControllerBase
    {

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        



        DB db = new DB("db.json");

        [HttpPost]
        public IActionResult Login(JObject payload)
        {
            bool loggedIn = false;
            loginClass newlogin = new loginClass();
            newlogin = JsonConvert.DeserializeObject<loginClass>(payload.ToString());
            foreach(User user in db.root.users.users)
            {
                if(newlogin.username == user.user && newlogin.password == user.password)
                {
                    return Ok("Success");

                }
                
            }
            return Ok("Fail");

        }

        [HttpPost]
        public IActionResult SendMessage(JObject payload)
        {
            message msg = new message();
            bool success = false;
            msg = JsonConvert.DeserializeObject<message>(payload.ToString());
            foreach (User user in db.root.users.users)
            {
                if (msg.username == user.user && msg.password == user.password)
                {
                    foreach(Conversation convo in user.conversations)
                    {
                        if((convo.user1== msg.username && convo.user2== msg.friend) || (convo.user1 == msg.friend && convo.user2==msg.username))
                        {
                            Message mess = new Message {content=msg.content, reciever=msg.friend, sender=msg.username };
                            convo.messages.Add(mess);
                            UpdateDB.Update(db);
                            success = true;
                        }
                    }
                }
            }

            return success ? Ok("Success") : Ok("Fail");
        }

        [HttpPost]
        public IActionResult GetMessages(JObject payload)
        {
            bool success = false;
            loginClass newlogin = new loginClass();
            newlogin = JsonConvert.DeserializeObject<loginClass>(payload.ToString());
            foreach (User user in db.root.users.users)
            {
                if (newlogin.username == user.user && newlogin.password == user.password)
                {
                    foreach(Conversation convo in user.conversations)
                    {
                        if(convo.user1 ==newlogin.friend || convo.user2 == newlogin.friend)
                        {
                            string json = JsonConvert.SerializeObject(convo);
                            return Ok(json);
                            success = true;
                        }
                    }

                }
            }
            return success ? Ok("Success") : Ok("Fail");

        }
        [HttpPost]
        public IActionResult AddFriend(JObject payload)
        {
            bool success = false;
            loginClass newlogin = new loginClass();
            foreach (User user in db.root.users.users)
            {
                if (newlogin.username == user.user && newlogin.password == user.password)
                {
                    foreach(User friend in db.root.users.users)
                    {
                        if(newlogin.friend == friend.user)
                        {
                            user.friends.Add(friend.user);
                            UpdateDB.Update(db);
                            success = true;
                        }
                    }

                }

            }
            return success ? Ok("Success") : Ok("Fail");
        }
        [HttpPost]
        public IActionResult CreateUser(JObject payload)
        {
            bool success = false;
            loginClass newlogin = new loginClass();
            newlogin = JsonConvert.DeserializeObject<loginClass>(payload.ToString());

            foreach (User user in db.root.users.users)
            {
                if (newlogin.username != user.user)
                {
                    success = true;

                }
                else
                {
                    success = false;
                }

            }
            if(success)
            {
                User newUser = new User {user=newlogin.username, password=newlogin.password,friends=new List<string>(), conversations= new List<Conversation>()};
                db.root.users.users.Add(newUser);
                UpdateDB.Update(db);
                return Ok("Success");
            }
            else
            {
                return Ok("Fail");
            }
        }
    }
    public class loginClass
    {
        public string username { get; set; }
        public string password { get; set; }
        public string friend { get; set; }
    }
    public class message
    {
        public string username { get; set; }
        public string password { get; set; }
        public string content { get; set; }
        public string friend { get; set; }
    }
}
