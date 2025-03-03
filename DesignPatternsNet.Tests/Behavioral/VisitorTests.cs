using DesignPatternsNet.Behavioral.Visitor;
using Xunit;

namespace DesignPatternsNet.Tests.Behavioral
{
    public class VisitorTests
    {
        [Fact]
        public void ConcreteComponentA_Accept_CallsVisitorVisitMethodWithCorrectType()
        {
            // Arrange
            var componentA = new ConcreteComponentA();
            var visitor1 = new ConcreteVisitor1();
            
            // Act
            var result = componentA.Accept(visitor1);
            
            // Assert
            Assert.NotNull(result);
            Assert.Contains("ConcreteVisitor1", result);
            Assert.Contains("Component A", result);
        }
        
        [Fact]
        public void ConcreteComponentB_Accept_CallsVisitorVisitMethodWithCorrectType()
        {
            // Arrange
            var componentB = new ConcreteComponentB();
            var visitor1 = new ConcreteVisitor1();
            
            // Act
            var result = componentB.Accept(visitor1);
            
            // Assert
            Assert.NotNull(result);
            Assert.Contains("ConcreteVisitor1", result);
            Assert.Contains("Component B", result);
        }
        
        [Fact]
        public void ConcreteVisitor1_VisitConcreteComponentA_HandlesComponentACorrectly()
        {
            // Arrange
            var componentA = new ConcreteComponentA();
            var visitor1 = new ConcreteVisitor1();
            
            // Act
            var result = visitor1.VisitConcreteComponentA(componentA);
            
            // Assert
            Assert.Contains("ConcreteVisitor1", result);
            Assert.Contains("Component A", result);
        }
        
        [Fact]
        public void ConcreteVisitor1_VisitConcreteComponentB_HandlesComponentBCorrectly()
        {
            // Arrange
            var componentB = new ConcreteComponentB();
            var visitor1 = new ConcreteVisitor1();
            
            // Act
            var result = visitor1.VisitConcreteComponentB(componentB);
            
            // Assert
            Assert.Contains("ConcreteVisitor1", result);
            Assert.Contains("Component B", result);
        }
        
        [Fact]
        public void ConcreteVisitor2_VisitConcreteComponentA_HandlesComponentACorrectly()
        {
            // Arrange
            var componentA = new ConcreteComponentA();
            var visitor2 = new ConcreteVisitor2();
            
            // Act
            var result = visitor2.VisitConcreteComponentA(componentA);
            
            // Assert
            Assert.Contains("ConcreteVisitor2", result);
            Assert.Contains("Component A", result);
        }
        
        [Fact]
        public void ConcreteVisitor2_VisitConcreteComponentB_HandlesComponentBCorrectly()
        {
            // Arrange
            var componentB = new ConcreteComponentB();
            var visitor2 = new ConcreteVisitor2();
            
            // Act
            var result = visitor2.VisitConcreteComponentB(componentB);
            
            // Assert
            Assert.Contains("ConcreteVisitor2", result);
            Assert.Contains("Component B", result);
        }
        
        [Fact]
        public void ClientCode_WithDifferentVisitors_WorksCorrectly()
        {
            // Arrange
            var components = new IComponent[] { new ConcreteComponentA(), new ConcreteComponentB() };
            var visitor1 = new ConcreteVisitor1();
            var visitor2 = new ConcreteVisitor2();
            
            // Act & Assert
            foreach (var component in components)
            {
                var result1 = component.Accept(visitor1);
                var result2 = component.Accept(visitor2);
                
                Assert.NotNull(result1);
                Assert.NotNull(result2);
                Assert.Contains(visitor1.GetName(), result1);
                Assert.Contains(visitor2.GetName(), result2);
            }
        }
    }
}
