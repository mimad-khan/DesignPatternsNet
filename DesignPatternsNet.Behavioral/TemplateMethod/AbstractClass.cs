using System.Collections.Generic;

namespace DesignPatternsNet.Behavioral.TemplateMethod
{
    /// <summary>
    /// The Abstract Class defines a template method that contains a skeleton of some
    /// algorithm, composed of calls to (usually) abstract primitive operations.
    /// 
    /// Concrete subclasses should implement these operations, but leave the
    /// template method itself intact.
    /// </summary>
    public abstract class AbstractClass
    {
        // The template method defines the skeleton of an algorithm.
        public List<string> TemplateMethod()
        {
            var steps = new List<string>();
            
            steps.Add("AbstractClass: Started template method");
            
            steps.Add($"AbstractClass: Executing BaseOperation1: {BaseOperation1()}");
            
            steps.Add($"AbstractClass: Executing RequiredOperation1: {RequiredOperation1()}");
            steps.Add($"AbstractClass: Executing RequiredOperation2: {RequiredOperation2()}");
            
            steps.Add($"AbstractClass: Executing Hook1: {Hook1()}");
            
            steps.Add($"AbstractClass: Executing BaseOperation2: {BaseOperation2()}");
            
            steps.Add($"AbstractClass: Executing Hook2: {Hook2()}");
            
            steps.Add("AbstractClass: Finished template method");
            
            return steps;
        }

        // These operations already have implementations.
        protected virtual string BaseOperation1()
        {
            return "Default implementation of BaseOperation1";
        }

        protected virtual string BaseOperation2()
        {
            return "Default implementation of BaseOperation2";
        }

        // These operations have to be implemented in subclasses.
        protected abstract string RequiredOperation1();
        protected abstract string RequiredOperation2();

        // These are "hooks." Subclasses may override them, but it's not mandatory
        // since the hooks already have default (but empty) implementation.
        protected virtual string Hook1()
        {
            return "Default implementation of Hook1";
        }

        protected virtual string Hook2()
        {
            return "Default implementation of Hook2";
        }
    }
}
