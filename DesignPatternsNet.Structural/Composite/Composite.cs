using System.Collections.Generic;
using System.Linq;

namespace DesignPatternsNet.Structural.Composite
{
    /// <summary>
    /// The Composite class represents the complex components that may have
    /// children. Usually, the Composite objects delegate the actual work to their
    /// children and then "sum-up" the result.
    /// </summary>
    public class Composite : Component
    {
        protected List<Component> _children = new List<Component>();

        public Composite(string name) : base(name)
        {
        }

        // A composite object can add or remove other components (both simple or
        // complex) to or from its child list.
        public override void Add(Component component)
        {
            _children.Add(component);
        }

        public override void Remove(Component component)
        {
            _children.Remove(component);
        }

        // The Composite executes its primary logic in a particular way. It
        // traverses recursively through all its children, collecting and summing
        // their results. Since the composite's children pass these calls to their
        // children and so forth, the whole object tree is traversed as a result.
        public override int GetPrice()
        {
            return _children.Sum(child => child.GetPrice());
        }

        public override bool IsComposite()
        {
            return true;
        }

        public IEnumerable<Component> GetChildren()
        {
            return _children;
        }
    }
}
