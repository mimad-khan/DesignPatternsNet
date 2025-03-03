using DesignPatternsNet.Behavioral.ChainOfResponsibility;
using Xunit;

namespace DesignPatternsNet.Tests.Behavioral
{
    public class ChainOfResponsibilityTests
    {
        [Fact]
        public void MonkeyHandler_Handle_ProcessesBananaRequest()
        {
            // Arrange
            var handler = new MonkeyHandler();
            var request = "Banana";
            
            // Act
            var result = handler.Handle(request);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Monkey: I'll eat the Banana", result);
        }
        
        [Fact]
        public void MonkeyHandler_PassesToSquirrelHandler_WhenRequestIsNutRequest()
        {
            // Arrange
            var monkeyHandler = new MonkeyHandler();
            var squirrelHandler = new SquirrelHandler();
            monkeyHandler.SetNext(squirrelHandler);
            var request = "Nut";
            
            // Act
            var result = monkeyHandler.Handle(request);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Squirrel: I'll eat the Nut", result);
        }
        
        [Fact]
        public void SquirrelHandler_Handle_ProcessesNutRequest()
        {
            // Arrange
            var handler = new SquirrelHandler();
            var request = "Nut";
            
            // Act
            var result = handler.Handle(request);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Squirrel: I'll eat the Nut", result);
        }
        
        [Fact]
        public void SquirrelHandler_PassesToDogHandler_WhenRequestIsMeatRequest()
        {
            // Arrange
            var squirrelHandler = new SquirrelHandler();
            var dogHandler = new DogHandler();
            squirrelHandler.SetNext(dogHandler);
            var request = "MeatBall";
            
            // Act
            var result = squirrelHandler.Handle(request);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Dog: I'll eat the MeatBall", result);
        }
        
        [Fact]
        public void DogHandler_Handle_ProcessesMeatRequest()
        {
            // Arrange
            var handler = new DogHandler();
            var request = "MeatBall";
            
            // Act
            var result = handler.Handle(request);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Dog: I'll eat the MeatBall", result);
        }
        
        [Fact]
        public void ChainOfHandlers_ReturnsCannotHandle_WhenNoHandlerCanProcess()
        {
            // Arrange
            var monkeyHandler = new MonkeyHandler();
            var squirrelHandler = new SquirrelHandler();
            var dogHandler = new DogHandler();
            monkeyHandler.SetNext(squirrelHandler);
            squirrelHandler.SetNext(dogHandler);
            var request = "Coffee";
            
            // Act
            var result = monkeyHandler.Handle(request);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal("None of the handlers can process the request: Coffee", result);
        }
        
        [Fact]
        public void ChainOfHandlers_ProcessesRequestByCorrectHandler()
        {
            // Arrange
            var monkeyHandler = new MonkeyHandler();
            var squirrelHandler = new SquirrelHandler();
            var dogHandler = new DogHandler();
            monkeyHandler.SetNext(squirrelHandler);
            squirrelHandler.SetNext(dogHandler);
            
            // Act
            var result1 = monkeyHandler.Handle("Banana");
            var result2 = monkeyHandler.Handle("Nut");
            var result3 = monkeyHandler.Handle("MeatBall");
            
            // Assert
            Assert.Equal("Monkey: I'll eat the Banana", result1);
            Assert.Equal("Squirrel: I'll eat the Nut", result2);
            Assert.Equal("Dog: I'll eat the MeatBall", result3);
        }
    }
}
