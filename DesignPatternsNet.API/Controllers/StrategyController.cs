using DesignPatternsNet.Behavioral.Strategy;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StrategyController : ControllerBase
    {
        private static readonly Context _context = new Context(new ConcreteStrategyA());
        private static readonly Dictionary<string, IStrategy> _strategies = new Dictionary<string, IStrategy>
        {
            { "a", new ConcreteStrategyA() },
            { "b", new ConcreteStrategyB() },
            { "c", new ConcreteStrategyC() }
        };

        [HttpGet]
        public IActionResult GetCurrentStrategy()
        {
            var strategy = _context.GetStrategy();
            
            return Ok(new
            {
                CurrentStrategy = strategy?.GetName() ?? "No strategy set",
                AvailableStrategies = GetAvailableStrategies(),
                Message = "Current strategy retrieved."
            });
        }

        [HttpPost("set/{strategyType}")]
        public IActionResult SetStrategy(string strategyType)
        {
            if (!_strategies.ContainsKey(strategyType.ToLower()))
            {
                return BadRequest(new
                {
                    Message = $"Unknown strategy type: {strategyType}. Use 'a', 'b', or 'c'."
                });
            }

            var previousStrategy = _context.GetStrategy()?.GetName() ?? "No strategy";
            var newStrategy = _strategies[strategyType.ToLower()];
            
            _context.SetStrategy(newStrategy);

            return Ok(new
            {
                PreviousStrategy = previousStrategy,
                CurrentStrategy = newStrategy.GetName(),
                Message = $"Strategy changed from '{previousStrategy}' to '{newStrategy.GetName()}'."
            });
        }

        [HttpPost("execute")]
        public IActionResult ExecuteStrategy([FromBody] StrategyRequest request)
        {
            if (_context.GetStrategy() == null)
            {
                return BadRequest(new
                {
                    Message = "No strategy set. Please set a strategy first."
                });
            }

            var result = _context.ExecuteStrategy(request.Data);

            return Ok(new
            {
                Strategy = _context.GetStrategy()!.GetName(),
                InputData = request.Data,
                Result = result,
                Message = $"Strategy '{_context.GetStrategy()!.GetName()}' executed successfully."
            });
        }

        [HttpPost("compare")]
        public IActionResult CompareStrategies([FromBody] StrategyRequest request)
        {
            var results = new List<object>();

            foreach (var strategy in _strategies.Values)
            {
                var result = strategy.DoAlgorithm(request.Data);
                results.Add(new
                {
                    Strategy = strategy.GetName(),
                    Result = result
                });
            }

            return Ok(new
            {
                InputData = request.Data,
                Results = results,
                Message = "All strategies compared."
            });
        }

        private List<string> GetAvailableStrategies()
        {
            var strategyNames = new List<string>();
            
            foreach (var strategy in _strategies.Values)
            {
                strategyNames.Add(strategy.GetName());
            }
            
            return strategyNames;
        }
    }

    public class StrategyRequest
    {
        public string Data { get; set; } = string.Empty;
    }
}
