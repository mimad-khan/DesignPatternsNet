using DesignPatternsNet.Structural.Flyweight;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlyweightController : ControllerBase
    {
        private static readonly FlyweightFactory _factory;

        static FlyweightController()
        {
            // Initialize the flyweight factory with some common states
            _factory = new FlyweightFactory("Red", "Green", "Blue", "Yellow", "Black");
        }

        [HttpGet]
        public IActionResult GetFlyweights()
        {
            return Ok(new
            {
                FlyweightCount = _factory.GetFlyweightCount(),
                AvailableFlyweights = _factory.ListFlyweights(),
                Message = "Flyweight pattern initialized with color flyweights."
            });
        }

        [HttpGet("{color}")]
        public IActionResult GetFlyweight(string color)
        {
            var flyweight = _factory.GetFlyweight(color);
            var intrinsicState = ((ConcreteFlyweight)flyweight).GetIntrinsicState();
            
            // Apply the flyweight with some extrinsic state
            flyweight.Operation($"Applied to position (10, 20)");

            return Ok(new
            {
                Color = color,
                IntrinsicState = intrinsicState,
                IsNewlyCreated = !_factory.ListFlyweights().Contains(color),
                TotalFlyweightCount = _factory.GetFlyweightCount(),
                Message = "Flyweight pattern successfully demonstrated."
            });
        }

        [HttpPost("bulk")]
        public IActionResult BulkUseFlyweights([FromBody] BulkFlyweightRequest request)
        {
            var results = new List<object>();
            var initialCount = _factory.GetFlyweightCount();

            foreach (var item in request.Items)
            {
                var flyweight = _factory.GetFlyweight(item.Color);
                flyweight.Operation($"Applied to position ({item.X}, {item.Y})");
                
                results.Add(new
                {
                    Color = item.Color,
                    Position = $"({item.X}, {item.Y})"
                });
            }

            return Ok(new
            {
                ProcessedItems = results,
                InitialFlyweightCount = initialCount,
                FinalFlyweightCount = _factory.GetFlyweightCount(),
                Message = "Bulk flyweight operation completed successfully."
            });
        }
    }

    public class BulkFlyweightRequest
    {
        public List<FlyweightItem> Items { get; set; } = new List<FlyweightItem>();
    }

    public class FlyweightItem
    {
        public string Color { get; set; } = string.Empty;
        public int X { get; set; }
        public int Y { get; set; }
    }
}
