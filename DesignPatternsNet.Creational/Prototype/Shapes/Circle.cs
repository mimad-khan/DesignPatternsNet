using DesignPatternsNet.Common.Drawing;
using System;

namespace DesignPatternsNet.Creational.Prototype.Shapes
{
    /// <summary>
    /// Concrete circle shape implementation
    /// </summary>
    public class Circle : IShape
    {
        public string Color { get; set; } = string.Empty;
        public Position Position { get; set; }
        public int Radius { get; set; }

        public Circle(int radius)
        {
            Radius = radius;
            Position = new Position(0, 0);
        }

        public IShape Clone()
        {
            Circle clone = new Circle(Radius)
            {
                Color = this.Color,
                Position = this.Position.Clone()
            };
            return clone;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing a {Color} circle at position {Position} with radius {Radius}");
        }
    }
}
