namespace DesignPatternsNet.Behavioral.Visitor
{
    /// <summary>
    /// Concrete Visitors implement several versions of the same algorithm, which can
    /// work with all concrete component classes.
    /// 
    /// You can experience the biggest benefit of the Visitor pattern when using it
    /// with a complex object structure, such as a Composite tree. In this case, it
    /// might be helpful to store some intermediate state of the algorithm while
    /// executing visitor's methods over various objects of the structure.
    /// </summary>
    public class ConcreteVisitor2 : IVisitor
    {
        public string VisitConcreteComponentA(ConcreteComponentA element)
        {
            return $"ConcreteVisitor2: Different approach to handle {element.GetName()} - transforming the exclusive method result: {element.ExclusiveMethodOfConcreteComponentA().ToUpper()}";
        }

        public string VisitConcreteComponentB(ConcreteComponentB element)
        {
            return $"ConcreteVisitor2: Different approach to handle {element.GetName()} - transforming the special method result: {element.SpecialMethodOfConcreteComponentB().ToUpper()}";
        }

        public string GetName()
        {
            return "Concrete Visitor 2";
        }
    }
}
