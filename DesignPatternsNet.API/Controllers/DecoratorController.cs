using DesignPatternsNet.Structural.Decorator;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DecoratorController : ControllerBase
    {
        [HttpGet("{decorators}")]
        public IActionResult DemonstrateDecorator(string decorators)
        {
            // Create the base component
            IComponent component = new ConcreteComponent();
            string originalResult = component.Operation();

            // Parse the decorator string (e.g., "ab" for both decorators, "a" for just A)
            var decoratorList = new List<string>();
            foreach (char c in decorators.ToLower())
            {
                if (c == 'a' || c == 'b')
                {
                    decoratorList.Add(c.ToString());
                }
            }

            // Apply decorators in the specified order
            foreach (var decorator in decoratorList)
            {
                if (decorator == "a")
                {
                    component = new ConcreteDecoratorA(component);
                }
                else if (decorator == "b")
                {
                    component = new ConcreteDecoratorB(component);
                }
            }

            // Get the final result
            string decoratedResult = component.Operation();

            return Ok(new
            {
                OriginalComponent = originalResult,
                AppliedDecorators = decoratorList,
                DecoratedResult = decoratedResult,
                Message = "Decorator pattern successfully demonstrated."
            });
        }
    }
}
