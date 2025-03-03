namespace DesignPatternsNet.Behavioral.State
{
    /// <summary>
    /// Concrete States implement various behaviors, associated with a state of the
    /// Context.
    /// </summary>
    public class ConcreteStateC : IState
    {
        public void Handle(Context context)
        {
            // C -> A transition (complete the cycle)
            context.TransitionTo(new ConcreteStateA());
        }

        public string GetStateName()
        {
            return "State C";
        }
    }
}
