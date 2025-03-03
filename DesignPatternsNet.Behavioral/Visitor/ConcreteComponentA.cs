namespace DesignPatternsNet.Behavioral.Visitor
{
    /// <summary>
    /// Each Concrete Component must implement the `Accept` method in such a way
    /// that it calls the visitor's method corresponding to the component's class.
    /// </summary>
    public class ConcreteComponentA : IComponent
    {
        // Note that we're calling `VisitConcreteComponentA`, which matches the
        // current class name. This way we let the visitor know the class of the
        // component it works with.
        public string Accept(IVisitor visitor)
        {
            return visitor.VisitConcreteComponentA(this);
        }

        // Concrete Components may have special methods that don't exist in their
        // base class or interface. The Visitor is still able to use these methods
        // since it's aware of the component's concrete class.
        public string ExclusiveMethodOfConcreteComponentA()
        {
            return "A special method of Component A";
        }

        public string GetName()
        {
            return "Component A";
        }
    }
}
