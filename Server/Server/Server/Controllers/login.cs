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
        [HttpPost]
        public IActionResult Login(JObject payload)
        {
            bool loggedIn = false;
            loginClass newlogin = new loginClass(); //loginClass has 3 members - username, password and friend(not necessary only for certain API calls)
            newlogin = JsonConvert.DeserializeObject<loginClass>(payload.ToString());
            foreach (User user in Globals.db.users)
            {
                if (newlogin.username == user.user && newlogin.password == user.password)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("New login from user " + newlogin.username);
                    Console.ForegroundColor = ConsoleColor.White;
                    return Ok("Success");
                }
            }
            Console.WriteLine("Fail login");
            return Ok("Fail");
        }
    }
}
