using DesignPatternsNet.Common.Computer;
using DesignPatternsNet.Creational.Builder;
using Xunit;

namespace DesignPatternsNet.Tests.Creational
{
    public class BuilderTests
    {
        [Fact]
        public void GamingComputerBuilder_Build_ReturnsGamingComputer()
        {
            // Arrange
            var builder = new GamingComputerBuilder();
            var director = new ComputerDirector();
            
            // Act
            var computer = director.BuildComputer(builder);
            
            // Assert
            Assert.NotNull(computer);
            Assert.NotNull(computer.CPU);
            Assert.NotNull(computer.GPU);
            Assert.NotNull(computer.RAM);
            Assert.NotNull(computer.Storage);
            Assert.NotNull(computer.Motherboard);
            Assert.NotNull(computer.PowerSupply);
            
            Assert.Contains("Gaming", computer.CPU.Model);
            Assert.Contains("RTX", computer.GPU.Model);
            Assert.True(computer.RAM.CapacityGB >= 16);
            Assert.True(computer.PowerSupply.WattageRating >= 750);
        }
        
        [Fact]
        public void WorkstationBuilder_Build_ReturnsWorkstationComputer()
        {
            // Arrange
            var builder = new WorkstationBuilder();
            var director = new ComputerDirector();
            
            // Act
            var computer = director.BuildComputer(builder);
            
            // Assert
            Assert.NotNull(computer);
            Assert.NotNull(computer.CPU);
            Assert.NotNull(computer.GPU);
            Assert.NotNull(computer.RAM);
            Assert.NotNull(computer.Storage);
            Assert.NotNull(computer.Motherboard);
            Assert.NotNull(computer.PowerSupply);
            
            Assert.Contains("Workstation", computer.CPU.Model);
            Assert.Contains("Quadro", computer.GPU.Model);
            Assert.True(computer.RAM.CapacityGB >= 32);
            Assert.True(computer.PowerSupply.WattageRating >= 850);
        }
    }
}
