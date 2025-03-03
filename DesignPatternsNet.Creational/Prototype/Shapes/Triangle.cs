using DesignPatternsNet.Common.Drawing;
using System;

namespace DesignPatternsNet.Creational.Prototype.Shapes
{
    /// <summary>
    /// Concrete triangle shape implementation
    /// </summary>
    public class Triangle : IShape
    {
        public string Color { get; set; } = string.Empty;
        public Position Position { get; set; }
        public Position Point2 { get; set; }
        public Position Point3 { get; set; }

        public Triangle(Position point2, Position point3)
        {
            Position = new Position(0, 0); // Point1
            Point2 = point2;
            Point3 = point3;
        }

        public IShape Clone()
        {
            Triangle clone = new Triangle(Point2.Clone(), Point3.Clone())
            {
                Color = this.Color,
                Position = this.Position.Clone()
            };
            return clone;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing a {Color} triangle at positions {Position}, {Point2}, and {Point3}");
        }
    }
}
