namespace DesignPatternsNet.Behavioral.Mediator
{
    /// <summary>
    /// Concrete Components implement various functionality. They don't depend on
    /// other components. They also don't depend on any concrete mediator classes.
    /// </summary>
    public class Component1 : BaseComponent
    {
        public void DoA()
        {
            _mediator.Notify(this, "A");
        }

        public void DoB()
        {
            _mediator.Notify(this, "B");
        }

        public string ReceiveMessage(string message)
        {
            return $"Component 1 received message: {message}";
        }
    }
}
