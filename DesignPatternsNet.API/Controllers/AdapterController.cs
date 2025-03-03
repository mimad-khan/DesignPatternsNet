using DesignPatternsNet.Structural.Adapter;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdapterController : ControllerBase
    {
        [HttpGet]
        public IActionResult DemonstrateAdapter()
        {
            // Client code that works with ITarget
            var target = new Adapter(new Adaptee());
            var result = target.GetRequest();

            return Ok(new
            {
                OriginalRequest = new Adaptee().GetSpecificRequest(),
                AdaptedRequest = result,
                Message = "Adapter pattern successfully demonstrated."
            });
        }
    }
}
