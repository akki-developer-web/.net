using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBanner()
        {
          
          
            return Ok("yayyy");
        }
    }
}
