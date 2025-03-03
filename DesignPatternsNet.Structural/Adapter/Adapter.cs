namespace DesignPatternsNet.Structural.Adapter
{
    /// <summary>
    /// The Adapter makes the Adaptee's interface compatible with the Target's interface
    /// </summary>
    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public string GetRequest()
        {
            // Translate the call to the Adaptee's method
            return $"Adapter: Translated [{_adaptee.GetSpecificRequest()}]";
        }
    }
}
