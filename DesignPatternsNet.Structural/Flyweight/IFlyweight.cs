namespace DesignPatternsNet.Structural.Flyweight
{
    /// <summary>
    /// The Flyweight interface declares methods that all concrete flyweights must implement.
    /// These methods accept extrinsic state as parameters.
    /// </summary>
    public interface IFlyweight
    {
        void Operation(string extrinsicState);
    }
}
