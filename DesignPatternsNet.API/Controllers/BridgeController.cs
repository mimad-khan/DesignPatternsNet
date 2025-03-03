using DesignPatternsNet.Structural.Bridge;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BridgeController : ControllerBase
    {
        [HttpGet("{implementationType}/{abstractionType}")]
        public IActionResult DemonstrateBridge(string implementationType, string abstractionType)
        {
            IImplementation implementation;
            
            // Select implementation based on parameter
            switch (implementationType.ToLower())
            {
                case "a":
                    implementation = new ConcreteImplementationA();
                    break;
                case "b":
                    implementation = new ConcreteImplementationB();
                    break;
                default:
                    return BadRequest($"Unsupported implementation type: {implementationType}. Use 'a' or 'b'.");
            }

            // Select abstraction based on parameter
            Abstraction abstraction;
            switch (abstractionType.ToLower())
            {
                case "base":
                    abstraction = new Abstraction(implementation);
                    break;
                case "extended":
                    abstraction = new ExtendedAbstraction(implementation);
                    break;
                default:
                    return BadRequest($"Unsupported abstraction type: {abstractionType}. Use 'base' or 'extended'.");
            }

            // Execute the operation
            var result = abstraction.Operation();

            return Ok(new
            {
                ImplementationType = implementationType,
                AbstractionType = abstractionType,
                Result = result,
                Message = "Bridge pattern successfully demonstrated."
            });
        }
    }
}
