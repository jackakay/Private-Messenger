using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendGroupMessage : Controller
    {
        public IActionResult SendMessage(JObject payload)
        {
            bool success = false;
            return success ? Ok("Success") : Ok("Fail");
        }
    }
}
