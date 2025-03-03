using System.Collections.Generic;
using System.Linq;

namespace DesignPatternsNet.Structural.Flyweight
{
    /// <summary>
    /// The Flyweight Factory creates and manages flyweight objects. It ensures
    /// that flyweights are shared correctly. When the client requests a flyweight,
    /// the factory either returns an existing instance or creates a new one, if it
    /// doesn't exist yet.
    /// </summary>
    public class FlyweightFactory
    {
        private readonly Dictionary<string, IFlyweight> _flyweights = new Dictionary<string, IFlyweight>();

        public FlyweightFactory(params string[] args)
        {
            foreach (var state in args)
            {
                _flyweights[state] = new ConcreteFlyweight(state);
            }
        }

        public IFlyweight GetFlyweight(string key)
        {
            if (!_flyweights.ContainsKey(key))
            {
                _flyweights[key] = new ConcreteFlyweight(key);
            }

            return _flyweights[key];
        }

        public int GetFlyweightCount()
        {
            return _flyweights.Count;
        }

        public List<string> ListFlyweights()
        {
            return _flyweights.Keys.ToList();
        }
    }
}
