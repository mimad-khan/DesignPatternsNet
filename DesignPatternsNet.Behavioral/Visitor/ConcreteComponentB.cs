namespace DesignPatternsNet.Behavioral.Visitor
{
    /// <summary>
    /// Each Concrete Component must implement the `Accept` method in such a way
    /// that it calls the visitor's method corresponding to the component's class.
    /// </summary>
    public class ConcreteComponentB : IComponent
    {
        // Same here: VisitConcreteComponentB => ConcreteComponentB
        public string Accept(IVisitor visitor)
        {
            return visitor.VisitConcreteComponentB(this);
        }

        // Concrete Components may have special methods that don't exist in their
        // base class or interface. The Visitor is still able to use these methods
        // since it's aware of the component's concrete class.
        public string SpecialMethodOfConcreteComponentB()
        {
            return "B special method";
        }

        public string GetName()
        {
            return "Component B";
        }
    }
}
