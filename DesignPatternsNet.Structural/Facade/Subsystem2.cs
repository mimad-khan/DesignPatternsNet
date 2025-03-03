namespace DesignPatternsNet.Structural.Facade
{
    /// <summary>
    /// Some facades can work with multiple subsystems at the same time.
    /// </summary>
    public class Subsystem2
    {
        public string Operation1()
        {
            return "Subsystem2: Get ready!";
        }

        public string OperationZ()
        {
            return "Subsystem2: Fire!";
        }
    }
}
