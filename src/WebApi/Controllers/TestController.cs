using Microsoft.AspNetCore.Mvc;

namespace DDDFramework.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("DDD Framework is running!");
        }
    }
}
