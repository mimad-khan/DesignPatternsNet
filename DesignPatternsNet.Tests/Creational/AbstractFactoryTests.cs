using DesignPatternsNet.Creational.AbstractFactory.Dark;
using DesignPatternsNet.Creational.AbstractFactory.Light;
using Xunit;

namespace DesignPatternsNet.Tests.Creational
{
    public class AbstractFactoryTests
    {
        [Fact]
        public void LightThemeFactory_CreateButton_ReturnsLightButton()
        {
            // Arrange
            var factory = new LightThemeFactory();
            
            // Act
            var button = factory.CreateButton();
            
            // Assert
            Assert.NotNull(button);
            Assert.Equal("Light Button", button.Text);
            Assert.Equal("#FFFFFF", button.Color);
        }
        
        [Fact]
        public void LightThemeFactory_CreateTextBox_ReturnsLightTextBox()
        {
            // Arrange
            var factory = new LightThemeFactory();
            
            // Act
            var textBox = factory.CreateTextBox();
            
            // Assert
            Assert.NotNull(textBox);
            Assert.Equal("#FFFFFF", textBox.BackgroundColor);
            Assert.Equal("#CCCCCC", textBox.BorderColor);
        }
        
        [Fact]
        public void DarkThemeFactory_CreateButton_ReturnsDarkButton()
        {
            // Arrange
            var factory = new DarkThemeFactory();
            
            // Act
            var button = factory.CreateButton();
            
            // Assert
            Assert.NotNull(button);
            Assert.Equal("Dark Button", button.Text);
            Assert.Equal("#333333", button.Color);
        }
        
        [Fact]
        public void DarkThemeFactory_CreateTextBox_ReturnsDarkTextBox()
        {
            // Arrange
            var factory = new DarkThemeFactory();
            
            // Act
            var textBox = factory.CreateTextBox();
            
            // Assert
            Assert.NotNull(textBox);
            Assert.Equal("#222222", textBox.BackgroundColor);
            Assert.Equal("#444444", textBox.BorderColor);
        }
    }
}
