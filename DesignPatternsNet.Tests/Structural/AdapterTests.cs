using DesignPatternsNet.Structural.Adapter;
using Xunit;

namespace DesignPatternsNet.Tests.Structural
{
    public class AdapterTests
    {
        [Fact]
        public void Adapter_GetRequest_ReturnsConvertedAdapteeResponse()
        {
            // Arrange
            var adaptee = new Adaptee();
            var adapter = new Adapter(adaptee);
            
            // Act
            var result = adapter.GetRequest();
            
            // Assert
            Assert.NotNull(result);
            Assert.Contains("specific request", result);
            Assert.Contains("Adaptee", result);
        }
        
        [Fact]
        public void Adaptee_GetSpecificRequest_ReturnsSpecificFormat()
        {
            // Arrange
            var adaptee = new Adaptee();
            
            // Act
            var result = adaptee.GetSpecificRequest();
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal("This is a specific request from the Adaptee.", result);
        }
        
        [Fact]
        public void Client_UsesTarget_WithoutKnowingAdaptee()
        {
            // Arrange
            ITarget target = new Adapter(new Adaptee());
            
            // Act
            var result = target.GetRequest();
            
            // Assert
            Assert.NotNull(result);
            Assert.Contains("ADAPTED", result);
        }
    }
}
