using DesignPatternsNet.Common.Computer;

namespace DesignPatternsNet.Creational.Builder
{
    /// <summary>
    /// Concrete builder for workstation computers
    /// </summary>
    public class WorkstationBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void SetName()
        {
            _computer.Name = "Professional Workstation";
        }

        public void BuildCPU()
        {
            _computer.CPU = new CPU("Intel", "Core i9-12900K", 16, 3.2);
        }

        public void BuildGPU()
        {
            _computer.GPU = new GPU("NVIDIA", "Quadro RTX 5000", 16, "GDDR6");
        }

        public void BuildRAM()
        {
            _computer.RAM = new RAM("Kingston", "ECC Server Memory", 64, "DDR4-3200");
        }

        public void BuildStorage()
        {
            _computer.Storage = new Storage("Western Digital", "Black SN850", 2000, "NVMe SSD");
        }

        public void BuildMotherboard()
        {
            _computer.Motherboard = new Motherboard("ASUS", "ProArt Z690-Creator", "LGA1700", "Z690");
        }

        public void BuildPowerSupply()
        {
            _computer.PowerSupply = new PowerSupply("Corsair", "HX1000", 1000);
        }

        public void SetWiFi()
        {
            _computer.HasWiFi = true;
        }

        public void SetBluetooth()
        {
            _computer.HasBluetooth = true;
        }

        public void SetCaseType()
        {
            _computer.CaseType = "Full Tower Workstation Case";
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }
}
