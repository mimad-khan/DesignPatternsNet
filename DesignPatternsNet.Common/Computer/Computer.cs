using System.Text;

namespace DesignPatternsNet.Common.Computer
{
    /// <summary>
    /// Computer class representing a complete computer configuration
    /// </summary>
    public class Computer
    {
        public string Name { get; set; } = string.Empty;
        public CPU? CPU { get; set; }
        public GPU? GPU { get; set; }
        public RAM? RAM { get; set; }
        public Storage? Storage { get; set; }
        public Motherboard? Motherboard { get; set; }
        public PowerSupply? PowerSupply { get; set; }
        public bool HasWiFi { get; set; }
        public bool HasBluetooth { get; set; }
        public string CaseType { get; set; } = string.Empty;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Computer: {Name}");
            sb.AppendLine($"CPU: {CPU?.Brand} {CPU?.Model} ({CPU?.Cores} cores, {CPU?.ClockSpeedGHz}GHz)");
            sb.AppendLine($"GPU: {GPU?.Brand} {GPU?.Model} ({GPU?.MemoryGB}GB {GPU?.Type})");
            sb.AppendLine($"RAM: {RAM?.Brand} {RAM?.Model} ({RAM?.CapacityGB}GB {RAM?.Type})");
            sb.AppendLine($"Storage: {Storage?.Brand} {Storage?.Model} ({Storage?.CapacityGB}GB {Storage?.Type})");
            sb.AppendLine($"Motherboard: {Motherboard?.Brand} {Motherboard?.Model} ({Motherboard?.SocketType}, {Motherboard?.ChipsetType})");
            sb.AppendLine($"Power Supply: {PowerSupply?.Brand} {PowerSupply?.Model} ({PowerSupply?.WattageRating}W)");
            sb.AppendLine($"WiFi: {(HasWiFi ? "Yes" : "No")}");
            sb.AppendLine($"Bluetooth: {(HasBluetooth ? "Yes" : "No")}");
            sb.AppendLine($"Case: {CaseType}");
            return sb.ToString();
        }
    }
}
