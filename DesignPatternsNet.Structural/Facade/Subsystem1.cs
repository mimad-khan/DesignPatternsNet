namespace DesignPatternsNet.Structural.Facade
{
    /// <summary>
    /// The Subsystem can accept requests either from the facade or client directly.
    /// In any case, to the Subsystem, the Facade is yet another client, and it's not
    /// a part of the Subsystem.
    /// </summary>
    public class Subsystem1
    {
        public string Operation1()
        {
            return "Subsystem1: Ready!";
        }

        public string OperationN()
        {
            return "Subsystem1: Go!";
        }
    }
}
