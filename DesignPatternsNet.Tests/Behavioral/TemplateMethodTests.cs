using DesignPatternsNet.Behavioral.TemplateMethod;
using Xunit;

namespace DesignPatternsNet.Tests.Behavioral
{
    public class TemplateMethodTests
    {
        [Fact]
        public void ConcreteClass1_TemplateMethod_ExecutesStepsInOrder()
        {
            // Arrange
            var concrete1 = new ConcreteClass1();
            
            // Act
            var result = concrete1.TemplateMethod();
            
            // Assert
            Assert.NotNull(result);
            Assert.True(result.Count >= 5);
            Assert.Contains("AbstractClass: Started template method", result[0]);
            Assert.Contains("AbstractClass: Executing BaseOperation1", result[1]);
            Assert.Contains("AbstractClass: Executing RequiredOperation1", result[2]);
            Assert.Contains("RequiredOperation1", result[2]);
        }
        
        [Fact]
        public void ConcreteClass2_TemplateMethod_ExecutesStepsInOrder()
        {
            // Arrange
            var concrete2 = new ConcreteClass2();
            
            // Act
            var result = concrete2.TemplateMethod();
            
            // Assert
            Assert.NotNull(result);
            Assert.True(result.Count >= 5);
            Assert.Contains("AbstractClass: Started template method", result[0]);
            Assert.Contains("AbstractClass: Executing BaseOperation1", result[1]);
            Assert.Contains("AbstractClass: Executing RequiredOperation1", result[2]);
            Assert.Contains("RequiredOperation1", result[2]);
        }
        
        [Fact]
        public void ConcreteClasses_RequiredOperation1_ImplementDifferently()
        {
            // Arrange
            var concrete1 = new ConcreteClass1();
            var concrete2 = new ConcreteClass2();
            
            // Act
            var result1 = concrete1.TemplateMethod();
            var result2 = concrete2.TemplateMethod();
            
            // Assert
            Assert.NotEqual(result1[2], result2[2]);
            Assert.Contains("ConcreteClass1", result1[2]);
            Assert.Contains("ConcreteClass2", result2[2]);
        }
        
        [Fact]
        public void ConcreteClasses_Hook1_ImplementDifferently()
        {
            // Arrange
            var concrete1 = new ConcreteClass1();
            var concrete2 = new ConcreteClass2();
            
            // Act
            var result1 = concrete1.TemplateMethod();
            var result2 = concrete2.TemplateMethod();
            
            // Assert
            // Find the hook1 results in both lists
            var hook1Result1 = result1.Find(s => s.Contains("Hook1"));
            var hook1Result2 = result2.Find(s => s.Contains("Hook1"));
            
            Assert.NotNull(hook1Result1);
            Assert.NotNull(hook1Result2);
            Assert.NotEqual(hook1Result1, hook1Result2);
            Assert.Contains("ConcreteClass1", hook1Result1);
            Assert.Contains("ConcreteClass2", hook1Result2);
        }
    }
}
