using System.Linq;

namespace DesignPatternsNet.Behavioral.Strategy
{
    /// <summary>
    /// Concrete Strategies implement the algorithm while following the base Strategy
    /// interface. The interface makes them interchangeable in the Context.
    /// </summary>
    public class ConcreteStrategyC : IStrategy
    {
        public string DoAlgorithm(string data)
        {
            // Sort the data by length of each element
            var result = string.Join(',', data.Split(',').OrderBy(x => x.Length));
            return result;
        }

        public string GetName()
        {
            return "Length Sort Strategy";
        }
    }
}
