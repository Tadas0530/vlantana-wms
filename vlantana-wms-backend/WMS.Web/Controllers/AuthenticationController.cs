using Microsoft.AspNetCore.Mvc;

namespace vlantana_wms_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet(Name = "GetGreeting")]
        public IActionResult GetGreeting()
        {
            return Content("Greetings I am working!");
        }
    }
}