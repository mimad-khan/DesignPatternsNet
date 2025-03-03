using DesignPatternsNet.Behavioral.Mediator;
using Xunit;

namespace DesignPatternsNet.Tests.Behavioral
{
    public class MediatorTests
    {
        [Fact]
        public void Component1_DoA_NotifiesComponent2()
        {
            // Arrange
            var component1 = new Component1();
            var component2 = new Component2();
            var mediator = new ConcreteMediator(component1, component2);
            
            // Act
            component1.DoA();
            var eventLog = mediator.GetEventLog();
            
            // Assert
            Assert.NotEmpty(eventLog);
            Assert.Equal(2, eventLog.Count);
            Assert.Contains("Mediator received event 'A' from Component1", eventLog[0]);
            Assert.Contains("Component 2 received message: Event A occurred", eventLog[1]);
        }
        
        [Fact]
        public void Component1_DoB_NotifiesComponent2()
        {
            // Arrange
            var component1 = new Component1();
            var component2 = new Component2();
            var mediator = new ConcreteMediator(component1, component2);
            
            // Act
            component1.DoB();
            var eventLog = mediator.GetEventLog();
            
            // Assert
            Assert.NotEmpty(eventLog);
            Assert.Equal(2, eventLog.Count);
            Assert.Contains("Mediator received event 'B' from Component1", eventLog[0]);
            Assert.Contains("Component 2 received message: Event B occurred", eventLog[1]);
        }
        
        [Fact]
        public void Component2_DoC_NotifiesComponent1()
        {
            // Arrange
            var component1 = new Component1();
            var component2 = new Component2();
            var mediator = new ConcreteMediator(component1, component2);
            
            // Act
            component2.DoC();
            var eventLog = mediator.GetEventLog();
            
            // Assert
            Assert.NotEmpty(eventLog);
            Assert.Equal(2, eventLog.Count);
            Assert.Contains("Mediator received event 'C' from Component2", eventLog[0]);
            Assert.Contains("Component 1 received message: Event C occurred", eventLog[1]);
        }
        
        [Fact]
        public void Component2_DoD_NotifiesComponent1()
        {
            // Arrange
            var component1 = new Component1();
            var component2 = new Component2();
            var mediator = new ConcreteMediator(component1, component2);
            
            // Act
            component2.DoD();
            var eventLog = mediator.GetEventLog();
            
            // Assert
            Assert.NotEmpty(eventLog);
            Assert.Equal(2, eventLog.Count);
            Assert.Contains("Mediator received event 'D' from Component2", eventLog[0]);
            Assert.Contains("Component 1 received message: Event D occurred", eventLog[1]);
        }
    }
}
