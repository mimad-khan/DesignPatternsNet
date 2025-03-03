namespace DesignPatternsNet.Behavioral.Visitor
{
    /// <summary>
    /// The Visitor Interface declares a set of visiting methods that correspond to
    /// component classes. The signature of a visiting method allows the visitor to
    /// identify the exact class of the component that it's dealing with.
    /// </summary>
    public interface IVisitor
    {
        string VisitConcreteComponentA(ConcreteComponentA element);
        string VisitConcreteComponentB(ConcreteComponentB element);
        string GetName();
    }
}
