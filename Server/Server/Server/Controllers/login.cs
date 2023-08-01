using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class login : ControllerBase
    {

        DB db = new DB("db.json");

        [HttpGet]
        public IActionResult Login()
        {
            foreach(User user in db.root.users.users)
            {
                
            }
            return Ok("test");
        }
    }
}
