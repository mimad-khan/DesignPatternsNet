using DesignPatternsNet.Common.Computer;

namespace DesignPatternsNet.Creational.Builder
{
    /// <summary>
    /// Director class that constructs the computer using the builder
    /// </summary>
    public class ComputerDirector
    {
        public Computer BuildComputer(IComputerBuilder builder)
        {
            builder.SetName();
            builder.BuildCPU();
            builder.BuildGPU();
            builder.BuildRAM();
            builder.BuildStorage();
            builder.BuildMotherboard();
            builder.BuildPowerSupply();
            builder.SetWiFi();
            builder.SetBluetooth();
            builder.SetCaseType();
            
            return builder.GetComputer();
        }
    }
}
