using DesignPatternsNet.Behavioral.Strategy;
using Xunit;

namespace DesignPatternsNet.Tests.Behavioral
{
    public class StrategyTests
    {
        [Fact]
        public void Context_WithoutStrategy_ReturnsNoStrategyMessage()
        {
            // Arrange
            var context = new Context();
            
            // Act
            var result = context.ExecuteStrategy("test data");
            
            // Assert
            Assert.Equal("No strategy set", result);
        }
        
        [Fact]
        public void Context_WithConcreteStrategyA_ExecutesStrategyA()
        {
            // Arrange
            var strategy = new ConcreteStrategyA();
            var context = new Context(strategy);
            
            // Act
            var result = context.ExecuteStrategy("test data");
            
            // Assert
            Assert.Equal("Strategy A: test data", result);
        }
        
        [Fact]
        public void Context_WithConcreteStrategyB_ExecutesStrategyB()
        {
            // Arrange
            var strategy = new ConcreteStrategyB();
            var context = new Context(strategy);
            
            // Act
            var result = context.ExecuteStrategy("test data");
            
            // Assert
            Assert.Equal("Strategy B: TEST DATA", result);
        }
        
        [Fact]
        public void Context_WithConcreteStrategyC_ExecutesStrategyC()
        {
            // Arrange
            var strategy = new ConcreteStrategyC();
            var context = new Context(strategy);
            
            // Act
            var result = context.ExecuteStrategy("test data");
            
            // Assert
            Assert.Equal("Strategy C: atad tset", result);
        }
        
        [Fact]
        public void Context_ChangingStrategy_ExecutesNewStrategy()
        {
            // Arrange
            var strategyA = new ConcreteStrategyA();
            var strategyB = new ConcreteStrategyB();
            var context = new Context(strategyA);
            
            // Act
            var resultA = context.ExecuteStrategy("test data");
            context.SetStrategy(strategyB);
            var resultB = context.ExecuteStrategy("test data");
            
            // Assert
            Assert.Equal("Strategy A: test data", resultA);
            Assert.Equal("Strategy B: TEST DATA", resultB);
        }
        
        [Fact]
        public void GetStrategy_ReturnsCurrentStrategy()
        {
            // Arrange
            var strategyA = new ConcreteStrategyA();
            var context = new Context(strategyA);
            
            // Act
            var strategy = context.GetStrategy();
            
            // Assert
            Assert.NotNull(strategy);
            Assert.Equal("Strategy A", strategy.GetName());
        }
    }
}
