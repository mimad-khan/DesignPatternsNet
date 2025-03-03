namespace DesignPatternsNet.Behavioral.TemplateMethod
{
    /// <summary>
    /// Concrete classes have to implement all abstract operations of the base class.
    /// They can also override some operations with a default implementation.
    /// </summary>
    public class ConcreteClass1 : AbstractClass
    {
        protected override string RequiredOperation1()
        {
            return "ConcreteClass1: Implemented RequiredOperation1";
        }

        protected override string RequiredOperation2()
        {
            return "ConcreteClass1: Implemented RequiredOperation2";
        }

        // ConcreteClass1 overrides the BaseOperation1 method
        protected override string BaseOperation1()
        {
            return "ConcreteClass1: Overridden BaseOperation1";
        }
    }
}
