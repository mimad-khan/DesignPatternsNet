using DesignPatternsNet.Structural.Bridge;
using Xunit;

namespace DesignPatternsNet.Tests.Structural
{
    public class BridgeTests
    {
        [Fact]
        public void Abstraction_WithImplementationA_OperatesCorrectly()
        {
            // Arrange
            var implementationA = new ConcreteImplementationA();
            var abstraction = new Abstraction(implementationA);
            
            // Act
            var result = abstraction.Operation();
            
            // Assert
            Assert.NotNull(result);
            Assert.Contains("Abstraction", result);
            Assert.Contains("ConcreteImplementationA", result);
        }
        
        [Fact]
        public void Abstraction_WithImplementationB_OperatesCorrectly()
        {
            // Arrange
            var implementationB = new ConcreteImplementationB();
            var abstraction = new Abstraction(implementationB);
            
            // Act
            var result = abstraction.Operation();
            
            // Assert
            Assert.NotNull(result);
            Assert.Contains("Abstraction", result);
            Assert.Contains("ConcreteImplementationB", result);
        }
        
        [Fact]
        public void ExtendedAbstraction_WithImplementationA_OperatesCorrectly()
        {
            // Arrange
            var implementationA = new ConcreteImplementationA();
            var extendedAbstraction = new ExtendedAbstraction(implementationA);
            
            // Act
            var result = extendedAbstraction.Operation();
            
            // Assert
            Assert.NotNull(result);
            Assert.Contains("ExtendedAbstraction", result);
            Assert.Contains("ConcreteImplementationA", result);
        }
        
        [Fact]
        public void ChangingImplementation_ChangesOperation()
        {
            // Arrange
            var implementationA = new ConcreteImplementationA();
            var implementationB = new ConcreteImplementationB();
            var abstraction = new Abstraction(implementationA);
            
            // Act
            var resultA = abstraction.Operation();
            
            // Create a new abstraction with implementationB
            abstraction = new Abstraction(implementationB);
            var resultB = abstraction.Operation();
            
            // Assert
            Assert.Contains("ConcreteImplementationA", resultA);
            Assert.Contains("ConcreteImplementationB", resultB);
        }
    }
}
