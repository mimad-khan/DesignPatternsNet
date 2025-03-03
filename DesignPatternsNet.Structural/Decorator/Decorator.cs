namespace DesignPatternsNet.Structural.Decorator
{
    /// <summary>
    /// The base Decorator class follows the same interface as the other components.
    /// The primary purpose of this class is to define the wrapping interface for all
    /// concrete decorators. The default implementation of the wrapping code might
    /// include a field for storing a wrapped component and the means to initialize it.
    /// </summary>
    public abstract class Decorator : IComponent
    {
        protected IComponent _component;

        public Decorator(IComponent component)
        {
            _component = component;
        }

        // The Decorator delegates all work to the wrapped component.
        public virtual string Operation()
        {
            return _component.Operation();
        }
    }
}
