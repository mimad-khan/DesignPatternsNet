namespace DesignPatternsNet.Behavioral.Memento
{
    /// <summary>
    /// The Originator holds some important state that may change over time.
    /// It also defines a method for saving the state inside a memento and another
    /// method for restoring the state from it.
    /// </summary>
    public class Originator
    {
        private string _state;

        public Originator(string state)
        {
            _state = state;
        }

        // The Originator's business logic may affect its internal state.
        // Therefore, the client should backup the state before launching
        // methods of the business logic via the save() method.
        public void DoSomething(string additionalText)
        {
            _state += " " + additionalText;
        }

        public string GetState()
        {
            return _state;
        }

        // Saves the current state inside a memento.
        public Memento Save()
        {
            return new Memento(_state);
        }

        // Restores the Originator's state from a memento object.
        public void Restore(Memento memento)
        {
            if (memento != null)
            {
                _state = memento.GetState();
            }
        }
    }
}
