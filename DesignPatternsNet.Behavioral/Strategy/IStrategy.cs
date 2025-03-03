namespace DesignPatternsNet.Behavioral.Strategy
{
    /// <summary>
    /// The Strategy interface declares operations common to all supported versions
    /// of some algorithm.
    /// 
    /// The Context uses this interface to call the algorithm defined by Concrete
    /// Strategies.
    /// </summary>
    public interface IStrategy
    {
        string DoAlgorithm(string data);
        string GetName();
    }
}
