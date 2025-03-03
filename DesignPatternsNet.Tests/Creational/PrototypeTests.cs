using DesignPatternsNet.Creational.Prototype.Shapes;
using DesignPatternsNet.Common.Drawing;
using Xunit;

namespace DesignPatternsNet.Tests.Creational
{
    public class PrototypeTests
    {
        [Fact]
        public void Circle_Clone_CreatesDeepCopy()
        {
            // Arrange
            var original = new Circle(15)
            {
                Position = new Position(10, 20),
                Color = "Red"
            };
            
            // Act
            var clone = original.Clone() as Circle;
            
            // Assert
            Assert.NotNull(clone);
            Assert.NotSame(original, clone);
            Assert.Equal(original.Position.X, clone?.Position.X);
            Assert.Equal(original.Position.Y, clone?.Position.Y);
            Assert.Equal(original.Radius, clone?.Radius);
            Assert.Equal(original.Color, clone?.Color);
        }
        
        [Fact]
        public void Rectangle_Clone_CreatesDeepCopy()
        {
            // Arrange
            var original = new Rectangle(50, 30)
            {
                Position = new Position(5, 10),
                Color = "Blue"
            };
            
            // Act
            var clone = original.Clone() as Rectangle;
            
            // Assert
            Assert.NotNull(clone);
            Assert.NotSame(original, clone);
            Assert.Equal(original.Position.X, clone?.Position.X);
            Assert.Equal(original.Position.Y, clone?.Position.Y);
            Assert.Equal(original.Width, clone?.Width);
            Assert.Equal(original.Height, clone?.Height);
            Assert.Equal(original.Color, clone?.Color);
        }
        
        [Fact]
        public void ModifyingClone_DoesNotAffectOriginal()
        {
            // Arrange
            var original = new Circle(15)
            {
                Position = new Position(10, 20),
                Color = "Red"
            };
            
            // Act
            var clone = original.Clone() as Circle;
            if (clone != null)
            {
                clone.Position = new Position(100, 200);
                clone.Radius = 50;
                clone.Color = "Green";
            }
            
            // Assert
            Assert.Equal(10, original.Position.X);
            Assert.Equal(20, original.Position.Y);
            Assert.Equal(15, original.Radius);
            Assert.Equal("Red", original.Color);
            
            Assert.Equal(100, clone?.Position.X);
            Assert.Equal(200, clone?.Position.Y);
            Assert.Equal(50, clone?.Radius);
            Assert.Equal("Green", clone?.Color);
        }
    }
}
