namespace DesignPatternsNet.Behavioral.Mediator
{
    /// <summary>
    /// Concrete Components implement various functionality. They don't depend on
    /// other components. They also don't depend on any concrete mediator classes.
    /// </summary>
    public class Component2 : BaseComponent
    {
        public void DoC()
        {
            _mediator.Notify(this, "C");
        }

        public void DoD()
        {
            _mediator.Notify(this, "D");
        }

        public string ReceiveMessage(string message)
        {
            return $"Component 2 received message: {message}";
        }
    }
}
