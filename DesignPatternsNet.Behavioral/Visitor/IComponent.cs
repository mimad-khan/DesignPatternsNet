namespace DesignPatternsNet.Behavioral.Visitor
{
    /// <summary>
    /// The Component interface declares an `accept` method that should take the
    /// base visitor interface as an argument.
    /// </summary>
    public interface IComponent
    {
        string Accept(IVisitor visitor);
        string GetName();
    }
}
