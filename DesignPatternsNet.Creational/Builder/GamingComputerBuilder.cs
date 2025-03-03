using DesignPatternsNet.Common.Computer;

namespace DesignPatternsNet.Creational.Builder
{
    /// <summary>
    /// Concrete builder for gaming computers
    /// </summary>
    public class GamingComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void SetName()
        {
            _computer.Name = "Gaming PC";
        }

        public void BuildCPU()
        {
            _computer.CPU = new CPU("AMD", "Ryzen 9 5900X", 12, 3.7);
        }

        public void BuildGPU()
        {
            _computer.GPU = new GPU("NVIDIA", "RTX 3080", 10, "GDDR6X");
        }

        public void BuildRAM()
        {
            _computer.RAM = new RAM("Corsair", "Vengeance RGB Pro", 32, "DDR4-3600");
        }

        public void BuildStorage()
        {
            _computer.Storage = new Storage("Samsung", "970 EVO Plus", 1000, "NVMe SSD");
        }

        public void BuildMotherboard()
        {
            _computer.Motherboard = new Motherboard("ASUS", "ROG Strix X570-E", "AM4", "X570");
        }

        public void BuildPowerSupply()
        {
            _computer.PowerSupply = new PowerSupply("EVGA", "SuperNOVA 850 G5", 850);
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
            _computer.CaseType = "Mid Tower ATX Gaming Case";
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }
}
