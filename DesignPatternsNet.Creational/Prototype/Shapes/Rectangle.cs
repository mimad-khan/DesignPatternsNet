using DesignPatternsNet.Common.Drawing;
using System;

namespace DesignPatternsNet.Creational.Prototype.Shapes
{
    /// <summary>
    /// Concrete rectangle shape implementation
    /// </summary>
    public class Rectangle : IShape
    {
        public string Color { get; set; } = string.Empty;
        public Position Position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
            Position = new Position(0, 0);
        }

        public IShape Clone()
        {
            Rectangle clone = new Rectangle(Width, Height)
            {
                Color = this.Color,
                Position = this.Position.Clone()
            };
            return clone;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing a {Color} rectangle at position {Position} with width {Width} and height {Height}");
        }
    }
}
