using System.Linq;

namespace DesignPatternsNet.Behavioral.Strategy
{
    /// <summary>
    /// Concrete Strategies implement the algorithm while following the base Strategy
    /// interface. The interface makes them interchangeable in the Context.
    /// </summary>
    public class ConcreteStrategyB : IStrategy
    {
        public string DoAlgorithm(string data)
        {
            // Sort the data in descending order
            var result = string.Join(',', data.Split(',').OrderByDescending(x => x));
            return result;
        }

        public string GetName()
        {
            return "Descending Sort Strategy";
        }
    }
}
