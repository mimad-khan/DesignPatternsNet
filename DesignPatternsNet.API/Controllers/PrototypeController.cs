using DesignPatternsNet.Common.Drawing;
using DesignPatternsNet.Creational.Prototype;
using DesignPatternsNet.Creational.Prototype.Shapes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrototypeController : ControllerBase
    {
        private static readonly ShapeRegistry _shapeRegistry;

        static PrototypeController()
        {
            // Initialize the shape registry with prototype shapes
            _shapeRegistry = new ShapeRegistry();
            
            // Register a red circle
            var redCircle = new Circle(10)
            {
                Color = "Red",
                Position = new Position(5, 5)
            };
            _shapeRegistry.RegisterShape("RedCircle", redCircle);
            
            // Register a blue rectangle
            var blueRectangle = new Rectangle(20, 10)
            {
                Color = "Blue",
                Position = new Position(10, 10)
            };
            _shapeRegistry.RegisterShape("BlueRectangle", blueRectangle);
            
            // Register a green triangle
            var greenTriangle = new Triangle(new Position(0, 10), new Position(10, 0))
            {
                Color = "Green",
                Position = new Position(0, 0)
            };
            _shapeRegistry.RegisterShape("GreenTriangle", greenTriangle);
        }

        [HttpGet("available")]
        public IActionResult GetAvailableShapes()
        {
            var shapes = _shapeRegistry.GetAvailableShapes();
            return Ok(new { Shapes = shapes });
        }

        [HttpGet("clone/{shapeName}")]
        public IActionResult CloneShape(string shapeName)
        {
            var shape = _shapeRegistry.GetShape(shapeName);
            
            if (shape == null)
            {
                return NotFound($"Shape with name '{shapeName}' not found");
            }

            // Draw the cloned shape
            shape.Draw();

            // Return shape details based on type
            var shapeDetails = GetShapeDetails(shape);

            return Ok(new
            {
                ShapeName = shapeName,
                Shape = shapeDetails,
                Message = $"Shape '{shapeName}' cloned successfully using the Prototype pattern."
            });
        }

        private object GetShapeDetails(IShape shape)
        {
            if (shape is Circle circle)
            {
                return new
                {
                    Type = "Circle",
                    Color = circle.Color,
                    Position = $"({circle.Position.X}, {circle.Position.Y})",
                    Radius = circle.Radius
                };
            }
            else if (shape is Rectangle rectangle)
            {
                return new
                {
                    Type = "Rectangle",
                    Color = rectangle.Color,
                    Position = $"({rectangle.Position.X}, {rectangle.Position.Y})",
                    Width = rectangle.Width,
                    Height = rectangle.Height
                };
            }
            else if (shape is Triangle triangle)
            {
                return new
                {
                    Type = "Triangle",
                    Color = triangle.Color,
                    Point1 = $"({triangle.Position.X}, {triangle.Position.Y})",
                    Point2 = $"({triangle.Point2.X}, {triangle.Point2.Y})",
                    Point3 = $"({triangle.Point3.X}, {triangle.Point3.Y})"
                };
            }

            return new
            {
                Type = "Unknown",
                Color = shape.Color,
                Position = $"({shape.Position.X}, {shape.Position.Y})"
            };
        }
    }
}
