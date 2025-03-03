namespace DesignPatternsNet.Structural.Composite
{
    /// <summary>
    /// The Leaf class represents the end objects of a composition. A leaf can't
    /// have any children. Usually, it's the Leaf objects that do the actual work,
    /// whereas Composite objects only delegate to their sub-components.
    /// </summary>
    public class Leaf : Component
    {
        private readonly int _price;

        public Leaf(string name, int price) : base(name)
        {
            _price = price;
        }

        public override int GetPrice()
        {
            return _price;
        }
    }
}
