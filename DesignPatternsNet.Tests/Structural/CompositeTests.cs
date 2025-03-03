using DesignPatternsNet.Structural.Composite;
using Xunit;

namespace DesignPatternsNet.Tests.Structural
{
    public class CompositeTests
    {
        [Fact]
        public void Leaf_GetPrice_ReturnsSinglePrice()
        {
            // Arrange
            var product = new Leaf("Keyboard", 50);
            
            // Act
            var price = product.GetPrice();
            
            // Assert
            Assert.Equal(50, price);
        }
        
        [Fact]
        public void Composite_GetPrice_ReturnsSumOfChildren()
        {
            // Arrange
            var box = new Composite("Computer Package");
            box.Add(new Leaf("Monitor", 200));
            box.Add(new Leaf("Keyboard", 50));
            box.Add(new Leaf("Mouse", 25));
            
            // Act
            var price = box.GetPrice();
            
            // Assert
            Assert.Equal(275, price);
        }
        
        [Fact]
        public void NestedComposite_GetPrice_ReturnsTotalSum()
        {
            // Arrange
            var mainBox = new Composite("Complete Package");
            
            var computerBox = new Composite("Computer Package");
            computerBox.Add(new Leaf("Monitor", 200));
            computerBox.Add(new Leaf("Keyboard", 50));
            computerBox.Add(new Leaf("Mouse", 25));
            
            var softwareBox = new Composite("Software Package");
            softwareBox.Add(new Leaf("Windows", 120));
            softwareBox.Add(new Leaf("Office", 150));
            
            mainBox.Add(computerBox);
            mainBox.Add(softwareBox);
            mainBox.Add(new Leaf("Headphones", 80));
            
            // Act
            var price = mainBox.GetPrice();
            
            // Assert
            Assert.Equal(625, price);
        }
        
        [Fact]
        public void RemovingComponent_UpdatesCompositePrice()
        {
            // Arrange
            var box = new Composite("Computer Package");
            var monitor = new Leaf("Monitor", 200);
            var keyboard = new Leaf("Keyboard", 50);
            var mouse = new Leaf("Mouse", 25);
            
            box.Add(monitor);
            box.Add(keyboard);
            box.Add(mouse);
            
            // Act
            var initialPrice = box.GetPrice();
            box.Remove(monitor);
            var finalPrice = box.GetPrice();
            
            // Assert
            Assert.Equal(275, initialPrice);
            Assert.Equal(75, finalPrice);
        }
    }
}
