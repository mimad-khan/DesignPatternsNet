using DesignPatternsNet.Structural.Facade;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacadeController : ControllerBase
    {
        [HttpGet]
        public IActionResult DemonstrateFacade()
        {
            // The client code may have some of the subsystem's objects already created.
            // In this case, it might be worthwhile to initialize the Facade with these
            // objects instead of letting the Facade create new instances.
            var subsystem1 = new Subsystem1();
            var subsystem2 = new Subsystem2();
            var facade = new Facade(subsystem1, subsystem2);
            
            string result = facade.Operation();

            return Ok(new
            {
                Result = result,
                Message = "Facade pattern successfully demonstrated."
            });
        }
    }
}
