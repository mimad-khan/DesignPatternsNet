namespace DesignPatternsNet.Behavioral.TemplateMethod
{
    /// <summary>
    /// Concrete classes have to implement all abstract operations of the base class.
    /// They can also override some operations with a default implementation.
    /// </summary>
    public class ConcreteClass2 : AbstractClass
    {
        protected override string RequiredOperation1()
        {
            return "ConcreteClass2: Implemented RequiredOperation1";
        }

        protected override string RequiredOperation2()
        {
            return "ConcreteClass2: Implemented RequiredOperation2";
        }

        // ConcreteClass2 overrides the Hook1 method
        protected override string Hook1()
        {
            return "ConcreteClass2: Overridden Hook1";
        }
        
        // ConcreteClass2 overrides the Hook2 method
        protected override string Hook2()
        {
            return "ConcreteClass2: Overridden Hook2";
        }
    }
}
