namespace DesignPatternsNet.Behavioral.State
{
    /// <summary>
    /// Concrete States implement various behaviors, associated with a state of the
    /// Context.
    /// </summary>
    public class ConcreteStateA : IState
    {
        public void Handle(Context context)
        {
            // A -> B transition
            context.TransitionTo(new ConcreteStateB());
        }

        public string GetStateName()
        {
            return "State A";
        }
    }
}
