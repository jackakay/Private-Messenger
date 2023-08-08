using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCreate : ControllerBase
    {
        

        [HttpPost]
        public IActionResult CreateUser(JObject payload)
        {
            bool success = false;
            loginClass newlogin = new loginClass();
            newlogin = JsonConvert.DeserializeObject<loginClass>(payload.ToString());

            foreach (User user in Globals.db.users)
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
            if (success)
            {
                User newUser = new User { user = newlogin.username, password = newlogin.password, friends = new List<string>()};
                Globals.db.users.Add(newUser);
                UpdateDB.Update(Globals.db);
                return Ok("Success");
            }
            else
            {
                return Ok("Fail");
            }
        }
    }
}

