using DesignPatternsNet.Behavioral.ChainOfResponsibility;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChainOfResponsibilityController : ControllerBase
    {
        private static readonly MonkeyHandler _monkey = new MonkeyHandler();
        private static readonly SquirrelHandler _squirrel = new SquirrelHandler();
        private static readonly DogHandler _dog = new DogHandler();

        static ChainOfResponsibilityController()
        {
            // Build the chain: monkey -> squirrel -> dog
            _monkey.SetNext(_squirrel).SetNext(_dog);
        }

        [HttpGet("{food}")]
        public IActionResult HandleFood(string food)
        {
            // The client should be able to send a request to any handler, not just
            // the first one in the chain.
            var result = _monkey.Handle(food);

            if (result != null)
            {
                return Ok(new
                {
                    Food = food,
                    Result = result,
                    Message = "Chain of Responsibility pattern successfully demonstrated."
                });
            }
            else
            {
                return Ok(new
                {
                    Food = food,
                    Result = $"No handler found for {food}",
                    Message = "Chain of Responsibility pattern successfully demonstrated."
                });
            }
        }

        [HttpGet("test-all")]
        public IActionResult TestAllHandlers()
        {
            var foods = new List<string> { "Banana", "Nut", "MeatBall", "Coffee" };
            var results = new List<object>();

            foreach (var food in foods)
            {
                var result = _monkey.Handle(food);
                results.Add(new
                {
                    Food = food,
                    Result = result ?? $"No handler found for {food}"
                });
            }

            return Ok(new
            {
                Results = results,
                Message = "Chain of Responsibility pattern tested with multiple inputs."
            });
        }
    }
}
