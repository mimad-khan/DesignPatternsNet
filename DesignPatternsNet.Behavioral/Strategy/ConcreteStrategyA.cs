using System.Linq;

namespace DesignPatternsNet.Behavioral.Strategy
{
    /// <summary>
    /// Concrete Strategies implement the algorithm while following the base Strategy
    /// interface. The interface makes them interchangeable in the Context.
    /// </summary>
    public class ConcreteStrategyA : IStrategy
    {
        public string DoAlgorithm(string data)
        {
            // Sort the data in ascending order
            var result = string.Join(',', data.Split(',').OrderBy(x => x));
            return result;
        }

        public string GetName()
        {
            return "Ascending Sort Strategy";
        }
    }
}
