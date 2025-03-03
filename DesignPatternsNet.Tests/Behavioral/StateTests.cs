using DesignPatternsNet.Behavioral.State;
using Xunit;

namespace DesignPatternsNet.Tests.Behavioral
{
    public class StateTests
    {
        [Fact]
        public void Context_InitialState_IsSetCorrectly()
        {
            // Arrange
            var stateA = new ConcreteStateA();
            
            // Act
            var context = new Context(stateA);
            
            // Assert
            Assert.NotNull(context.GetCurrentState());
            Assert.Equal("State A", context.GetCurrentState().GetStateName());
            Assert.Single(context.GetStateHistory());
            Assert.Contains("Transitioned to State A state", context.GetStateHistory()[0]);
        }
        
        [Fact]
        public void Context_TransitionTo_ChangesState()
        {
            // Arrange
            var stateA = new ConcreteStateA();
            var stateB = new ConcreteStateB();
            var context = new Context(stateA);
            
            // Act
            context.TransitionTo(stateB);
            
            // Assert
            Assert.Equal("State B", context.GetCurrentState().GetStateName());
            Assert.Equal(2, context.GetStateHistory().Count);
            Assert.Contains("Transitioned to State B state", context.GetStateHistory()[1]);
        }
        
        [Fact]
        public void ConcreteStateA_Handle_TransitionsToStateB()
        {
            // Arrange
            var stateA = new ConcreteStateA();
            var context = new Context(stateA);
            
            // Act
            context.Request();
            
            // Assert
            Assert.Equal("State B", context.GetCurrentState().GetStateName());
            Assert.Equal(2, context.GetStateHistory().Count);
        }
        
        [Fact]
        public void ConcreteStateB_Handle_TransitionsToStateC()
        {
            // Arrange
            var stateB = new ConcreteStateB();
            var context = new Context(stateB);
            
            // Act
            context.Request();
            
            // Assert
            Assert.Equal("State C", context.GetCurrentState().GetStateName());
            Assert.Equal(2, context.GetStateHistory().Count);
        }
        
        [Fact]
        public void ConcreteStateC_Handle_TransitionsToStateA()
        {
            // Arrange
            var stateC = new ConcreteStateC();
            var context = new Context(stateC);
            
            // Act
            context.Request();
            
            // Assert
            Assert.Equal("State A", context.GetCurrentState().GetStateName());
            Assert.Equal(2, context.GetStateHistory().Count);
        }
        
        [Fact]
        public void Context_MultipleRequests_CyclesThroughStates()
        {
            // Arrange
            var stateA = new ConcreteStateA();
            var context = new Context(stateA);
            
            // Act
            context.Request(); // A -> B
            context.Request(); // B -> C
            context.Request(); // C -> A
            context.Request(); // A -> B
            
            // Assert
            Assert.Equal("State B", context.GetCurrentState().GetStateName());
            Assert.Equal(5, context.GetStateHistory().Count);
            Assert.Contains("Transitioned to State A state", context.GetStateHistory()[0]);
            Assert.Contains("Transitioned to State B state", context.GetStateHistory()[1]);
            Assert.Contains("Transitioned to State C state", context.GetStateHistory()[2]);
            Assert.Contains("Transitioned to State A state", context.GetStateHistory()[3]);
            Assert.Contains("Transitioned to State B state", context.GetStateHistory()[4]);
        }
    }
}
