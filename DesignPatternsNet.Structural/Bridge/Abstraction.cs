namespace DesignPatternsNet.Structural.Bridge
{
    /// <summary>
    /// The Abstraction defines the interface for the "control" part of the two
    /// class hierarchies. It maintains a reference to an object of the
    /// Implementation hierarchy and delegates all of the real work to this object.
    /// </summary>
    public class Abstraction
    {
        protected IImplementation _implementation;

        public Abstraction(IImplementation implementation)
        {
            _implementation = implementation;
        }

        public virtual string Operation()
        {
            return $"Abstraction: Base operation with:\n{_implementation.OperationImplementation()}";
        }
    }
}
