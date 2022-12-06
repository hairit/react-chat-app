using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chatapp_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string run()
        {
            return "Server is running on port:";
        }
    }
}
