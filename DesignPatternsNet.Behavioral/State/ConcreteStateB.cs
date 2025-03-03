namespace DesignPatternsNet.Behavioral.State
{
    /// <summary>
    /// Concrete States implement various behaviors, associated with a state of the
    /// Context.
    /// </summary>
    public class ConcreteStateB : IState
    {
        public void Handle(Context context)
        {
            // B -> C transition
            context.TransitionTo(new ConcreteStateC());
        }

        public string GetStateName()
        {
            return "State B";
        }
    }
}
