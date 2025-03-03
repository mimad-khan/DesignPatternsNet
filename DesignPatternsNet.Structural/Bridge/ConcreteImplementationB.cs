namespace DesignPatternsNet.Structural.Bridge
{
    /// <summary>
    /// Each Concrete Implementation corresponds to a specific platform and
    /// implements the Implementation interface using that platform's API.
    /// </summary>
    public class ConcreteImplementationB : IImplementation
    {
        public string OperationImplementation()
        {
            return "ConcreteImplementationB: The result in platform B.";
        }
    }
}
