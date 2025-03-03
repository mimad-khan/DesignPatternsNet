using DesignPatternsNet.Common.Computer;

namespace DesignPatternsNet.Creational.Builder
{
    /// <summary>
    /// Builder interface for constructing computer configurations
    /// </summary>
    public interface IComputerBuilder
    {
        void SetName();
        void BuildCPU();
        void BuildGPU();
        void BuildRAM();
        void BuildStorage();
        void BuildMotherboard();
        void BuildPowerSupply();
        void SetWiFi();
        void SetBluetooth();
        void SetCaseType();
        Computer GetComputer();
    }
}
