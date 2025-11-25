using Microsoft.AspNetCore.Mvc;
using AuthenticationLogic.Interfaces;

namespace PortProjectTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly IPublicService _publicService;

        public TestController (IPublicService publicService)
        {
            _publicService = publicService;
        }

        [HttpGet("health")]
        public IActionResult GetHealth()
        {
            var result = _publicService.Health();
            
            return Ok(new
            {
                status = "OK",
                Timestamp = result
            });
        }

    }
}
