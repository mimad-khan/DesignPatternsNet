namespace DesignPatternsNet.Common.Computer
{
    // Records for computer components
    public record CPU(string Brand, string Model, int Cores, double ClockSpeedGHz);
    
    public record GPU(string Brand, string Model, int MemoryGB, string Type);
    
    public record RAM(string Brand, string Model, int CapacityGB, string Type);
    
    public record Storage(string Brand, string Model, int CapacityGB, string Type);
    
    public record Motherboard(string Brand, string Model, string SocketType, string ChipsetType);
    
    public record PowerSupply(string Brand, string Model, int WattageRating);
}
