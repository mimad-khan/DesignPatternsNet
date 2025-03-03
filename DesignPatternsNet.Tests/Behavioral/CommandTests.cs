using DesignPatternsNet.Behavioral.Command;
using Xunit;
using System.Linq;

namespace DesignPatternsNet.Tests.Behavioral
{
    public class CommandTests
    {
        [Fact]
        public void AddItemCommand_Execute_AddsItemToReceiver()
        {
            // Arrange
            var receiver = new Receiver();
            var command = new AddItemCommand(receiver, "Test Item");
            
            // Act
            command.Execute();
            
            // Assert
            Assert.Single(receiver.GetItems());
            Assert.Contains("Test Item", receiver.GetItems());
        }
        
        [Fact]
        public void AddItemCommand_Undo_RemovesItemFromReceiver()
        {
            // Arrange
            var receiver = new Receiver();
            var command = new AddItemCommand(receiver, "Test Item");
            command.Execute();
            
            // Act
            command.Undo();
            
            // Assert
            Assert.Empty(receiver.GetItems());
        }
        
        [Fact]
        public void RemoveItemCommand_Execute_RemovesItemFromReceiver()
        {
            // Arrange
            var receiver = new Receiver();
            receiver.AddItem("Test Item");
            var command = new RemoveItemCommand(receiver, "Test Item");
            
            // Act
            command.Execute();
            
            // Assert
            Assert.Empty(receiver.GetItems());
        }
        
        [Fact]
        public void RemoveItemCommand_Undo_AddsItemBackToReceiver()
        {
            // Arrange
            var receiver = new Receiver();
            receiver.AddItem("Test Item");
            var command = new RemoveItemCommand(receiver, "Test Item");
            command.Execute();
            
            // Act
            command.Undo();
            
            // Assert
            Assert.Single(receiver.GetItems());
            Assert.Contains("Test Item", receiver.GetItems());
        }
        
        [Fact]
        public void ClearItemsCommand_Execute_RemovesAllItemsFromReceiver()
        {
            // Arrange
            var receiver = new Receiver();
            receiver.AddItem("Item 1");
            receiver.AddItem("Item 2");
            receiver.AddItem("Item 3");
            var command = new ClearItemsCommand(receiver);
            
            // Act
            command.Execute();
            
            // Assert
            Assert.Empty(receiver.GetItems());
        }
        
        [Fact]
        public void Invoker_ExecuteCommand_AddsToHistory()
        {
            // Arrange
            var invoker = new Invoker();
            var receiver = new Receiver();
            var command1 = new AddItemCommand(receiver, "Item 1");
            var command2 = new RemoveItemCommand(receiver, "Item 2");
            
            // Act
            invoker.ExecuteCommand(command1);
            invoker.ExecuteCommand(command2);
            var history = invoker.GetCommandHistory();
            
            // Assert
            Assert.Equal(2, history.Count);
            Assert.Contains("Add Item: Item 1", history);
            Assert.Contains("Remove Item: Item 2", history);
        }
        
        [Fact]
        public void Invoker_CanUndo_ReturnsTrueWhenHistoryExists()
        {
            // Arrange
            var invoker = new Invoker();
            var receiver = new Receiver();
            var command = new AddItemCommand(receiver, "Test Item");
            
            // Act
            invoker.ExecuteCommand(command);
            
            // Assert
            Assert.True(invoker.CanUndo());
        }
        
        [Fact]
        public void Invoker_CanUndo_ReturnsFalseWhenHistoryEmpty()
        {
            // Arrange
            var invoker = new Invoker();
            
            // Act & Assert
            Assert.False(invoker.CanUndo());
        }
        
        [Fact]
        public void Invoker_Undo_RemovesCommandFromHistory()
        {
            // Arrange
            var invoker = new Invoker();
            var receiver = new Receiver();
            var command1 = new AddItemCommand(receiver, "Item 1");
            var command2 = new RemoveItemCommand(receiver, "Item 2");
            
            invoker.ExecuteCommand(command1);
            invoker.ExecuteCommand(command2);
            
            // Act
            var undoneCommand = invoker.Undo();
            var history = invoker.GetCommandHistory();
            
            // Assert
            Assert.Equal("Remove Item: Item 2", undoneCommand.GetDescription());
            Assert.Single(history);
            Assert.Contains("Add Item: Item 1", history);
            Assert.DoesNotContain("Remove Item: Item 2", history);
        }
        
        [Fact]
        public void Invoker_Undo_ReturnsNullWhenHistoryEmpty()
        {
            // Arrange
            var invoker = new Invoker();
            
            // Act
            var result = invoker.Undo();
            
            // Assert
            Assert.Null(result);
        }
    }
}
