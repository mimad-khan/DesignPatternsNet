namespace DesignPatternsNet.Structural.Decorator
{
    /// <summary>
    /// Concrete Components provide default implementations of the operations.
    /// </summary>
    public class ConcreteComponent : IComponent
    {
        public string Operation()
        {
            return "ConcreteComponent";
        }
    }
}
