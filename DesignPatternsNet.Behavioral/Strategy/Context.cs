namespace DesignPatternsNet.Behavioral.Strategy
{
    /// <summary>
    /// The Context defines the interface of interest to clients.
    /// </summary>
    public class Context
    {
        // The Context maintains a reference to one of the Strategy objects. The
        // Context does not know the concrete class of a strategy. It should work
        // with all strategies via the Strategy interface.
        private IStrategy? _strategy;

        public Context()
        {
        }

        // Usually, the Context accepts a strategy through the constructor, but also
        // provides a setter to change it at runtime.
        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        // Usually, the Context allows replacing a Strategy object at runtime.
        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        // The Context delegates some work to the Strategy object instead of
        // implementing multiple versions of the algorithm on its own.
        public string ExecuteStrategy(string data)
        {
            if (_strategy == null)
            {
                return "No strategy set";
            }
            
            var result = _strategy.DoAlgorithm(data);
            return result;
        }

        public IStrategy? GetStrategy()
        {
            return _strategy;
        }
    }
}
