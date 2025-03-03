namespace DesignPatternsNet.Structural.Flyweight
{
    /// <summary>
    /// The ConcreteFlyweight class implements the Flyweight interface and stores
    /// intrinsic state. Any state that it stores must be independent from the
    /// context, i.e., it must be shareable.
    /// </summary>
    public class ConcreteFlyweight : IFlyweight
    {
        private readonly string _intrinsicState;

        public ConcreteFlyweight(string intrinsicState)
        {
            _intrinsicState = intrinsicState;
        }

        public void Operation(string extrinsicState)
        {
            // The Operation method combines intrinsic and extrinsic state
            // but we only return a string representation for demonstration
        }

        public string GetIntrinsicState()
        {
            return _intrinsicState;
        }
    }
}
