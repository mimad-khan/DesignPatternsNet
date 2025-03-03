namespace DesignPatternsNet.Structural.Bridge
{
    /// <summary>
    /// The Implementation defines the interface for all implementation classes.
    /// It doesn't have to match the Abstraction's interface. In fact, the two
    /// interfaces can be entirely different.
    /// </summary>
    public interface IImplementation
    {
        string OperationImplementation();
    }
}
