using DesignPatternsNet.Behavioral.Observer;
using System.Reflection;
using Xunit;

namespace DesignPatternsNet.Tests.Behavioral
{
    public class ObserverTests
    {
        [Fact]
        public void Subject_Attach_AddsObserver()
        {
            // Arrange
            var subject = new Subject();
            var observer = new ConcreteObserverA("Observer1");
            
            // Act
            subject.Attach(observer);
            subject.SomeBusinessLogic(); // This will set a random state and notify observers
            
            // Assert
            Assert.NotEqual(0, observer.LastState); // State should have changed from default 0
            Assert.Contains("ConcreteObserverA: Observer1 reacted to the event", observer.LastReaction);
        }
        
        [Fact]
        public void Subject_Detach_RemovesObserver()
        {
            // Arrange
            var subject = new Subject();
            var observer = new ConcreteObserverA("Observer1");
            subject.Attach(observer);
            
            // Act
            subject.Detach(observer);
            var initialState = observer.LastState;
            subject.SomeBusinessLogic(); // This will set a random state and notify observers
            
            // Assert
            Assert.Equal(initialState, observer.LastState); // State should not have changed
        }
        
        [Fact]
        public void Subject_Notify_UpdatesAllObservers()
        {
            // Arrange
            var subject = new Subject();
            var observerA1 = new ConcreteObserverA("ObserverA1");
            var observerA2 = new ConcreteObserverA("ObserverA2");
            var observerB = new ConcreteObserverB("ObserverB");
            
            subject.Attach(observerA1);
            subject.Attach(observerA2);
            subject.Attach(observerB);
            
            // Act - use reflection to set the state since it has a private setter
            SetSubjectState(subject, 5);
            subject.Notify();
            
            // Assert
            Assert.Equal(5, observerA1.LastState);
            Assert.Equal(5, observerA2.LastState);
            Assert.Equal(5, observerB.LastState);
            
            Assert.Contains("ObserverA1 reacted to the event", observerA1.LastReaction);
            Assert.Contains("ObserverA2 reacted to the event", observerA2.LastReaction);
            Assert.Contains("ObserverB reacted to the event", observerB.LastReaction);
        }
        
        [Fact]
        public void Observers_ReactDifferently_BasedOnState()
        {
            // Arrange
            var subject = new Subject();
            var observerA = new ConcreteObserverA("ObserverA");
            var observerB = new ConcreteObserverB("ObserverB");
            
            subject.Attach(observerA);
            subject.Attach(observerB);
            
            // Act - set state to trigger different reactions
            SetSubjectState(subject, 2); // Less than 3
            subject.Notify();
            var reactionA_LowState = observerA.LastReaction;
            var reactionB_LowState = observerB.LastReaction;
            
            SetSubjectState(subject, 5); // Greater than 3
            subject.Notify();
            var reactionA_HighState = observerA.LastReaction;
            var reactionB_HighState = observerB.LastReaction;
            
            // Assert
            Assert.Contains("State is less than 3", reactionA_LowState);
            Assert.Contains("State is 3 or greater", reactionA_HighState);
            
            Assert.Contains("didn't react much", reactionB_LowState);
            Assert.Contains("was very interested", reactionB_HighState);
        }
        
        // Helper method to set the state using reflection (since State has a private setter)
        private void SetSubjectState(Subject subject, int state)
        {
            // Use reflection to set the private field that backs the State property
            var type = typeof(Subject);
            var field = type.GetField("_state", BindingFlags.NonPublic | BindingFlags.Instance);
            if (field != null)
            {
                field.SetValue(subject, state);
            }
            else
            {
                // If there's no backing field, try to set the property directly using reflection
                var property = type.GetProperty("State");
                if (property != null)
                {
                    property.SetValue(subject, state, null);
                }
            }
        }
    }
}
