using DesignPatternsNet.Behavioral.Memento;
using Xunit;

namespace DesignPatternsNet.Tests.Behavioral
{
    public class MementoTests
    {
        [Fact]
        public void Originator_Save_CreatesMemento()
        {
            // Arrange
            var originator = new Originator("Initial state");
            
            // Act
            var memento = originator.Save();
            
            // Assert
            Assert.NotNull(memento);
            Assert.Equal("Initial state", memento.GetState());
        }
        
        [Fact]
        public void Originator_Restore_SetsStateFromMemento()
        {
            // Arrange
            var originator = new Originator("Initial state");
            var memento = originator.Save();
            
            // Act
            originator.DoSomething("changed");
            Assert.Equal("Initial state changed", originator.GetState());
            
            originator.Restore(memento);
            
            // Assert
            Assert.Equal("Initial state", originator.GetState());
        }
        
        [Fact]
        public void Caretaker_Backup_StoresMemento()
        {
            // Arrange
            var originator = new Originator("Initial state");
            var caretaker = new Caretaker(originator);
            
            // Act
            caretaker.Backup();
            var history = caretaker.ShowHistory();
            
            // Assert
            Assert.NotEmpty(history);
            Assert.Single(history);
        }
        
        [Fact]
        public void Caretaker_Undo_RestoresPreviousState()
        {
            // Arrange
            var originator = new Originator("Initial state");
            var caretaker = new Caretaker(originator);
            
            // Initial backup
            caretaker.Backup();
            
            // Change state and backup again
            originator.DoSomething("changed");
            caretaker.Backup();
            
            // Act
            var stateBeforeUndo = originator.GetState();
            caretaker.Undo();
            var stateAfterUndo = originator.GetState();
            
            // Assert
            Assert.Equal("Initial state changed", stateBeforeUndo);
            Assert.Equal("Initial state", stateAfterUndo);
        }
        
        [Fact]
        public void Caretaker_MultipleUndos_RestoresStatesInReverseOrder()
        {
            // Arrange
            var originator = new Originator("State 0");
            var caretaker = new Caretaker(originator);
            caretaker.Backup();
            
            // Add more states
            originator.DoSomething("1");
            caretaker.Backup();
            
            originator.DoSomething("2");
            caretaker.Backup();
            
            originator.DoSomething("3");
            caretaker.Backup();
            
            // Act & Assert
            Assert.Equal("State 0 1 2 3", originator.GetState());
            
            caretaker.Undo();
            Assert.Equal("State 0 1 2", originator.GetState());
            
            caretaker.Undo();
            Assert.Equal("State 0 1", originator.GetState());
            
            caretaker.Undo();
            Assert.Equal("State 0", originator.GetState());
        }
    }
}
