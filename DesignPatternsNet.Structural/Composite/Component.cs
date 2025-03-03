using System;
using System.Collections.Generic;

namespace DesignPatternsNet.Structural.Composite
{
    /// <summary>
    /// The base Component class declares common operations for both simple and
    /// complex objects of a composition.
    /// </summary>
    public abstract class Component
    {
        public string Name { get; }

        protected Component(string name)
        {
            Name = name;
        }

        // The base Component may implement some default behavior or leave it to
        // concrete classes (by declaring the method as abstract).
        public abstract int GetPrice();

        public virtual void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(Component component)
        {
            throw new NotImplementedException();
        }

        // You can provide a method that lets the client code figure out whether
        // a component can have children.
        public virtual bool IsComposite()
        {
            return false;
        }
    }
}
