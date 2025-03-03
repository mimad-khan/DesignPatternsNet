namespace DesignPatternsNet.Structural.Bridge
{
    /// <summary>
    /// Each Concrete Implementation corresponds to a specific platform and
    /// implements the Implementation interface using that platform's API.
    /// </summary>
    public class ConcreteImplementationA : IImplementation
    {
        public string OperationImplementation()
        {
            return "ConcreteImplementationA: The result in platform A.";
        }
    }
}
