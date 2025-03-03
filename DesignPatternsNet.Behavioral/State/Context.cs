using System.Collections.Generic;

namespace DesignPatternsNet.Behavioral.State
{
    /// <summary>
    /// The Context defines the interface of interest to clients. It also maintains
    /// a reference to an instance of a State subclass, which represents the current
    /// state of the Context.
    /// </summary>
    public class Context
    {
        // A reference to the current state of the Context.
        private IState _state = null!;
        
        // A list to keep track of the state transitions
        private readonly List<string> _stateHistory = new List<string>();

        public Context(IState state)
        {
            TransitionTo(state);
        }

        // The Context allows changing the State object at runtime.
        public void TransitionTo(IState state)
        {
            _state = state;
            _stateHistory.Add($"Transitioned to {state.GetStateName()} state");
        }

        // The Context delegates part of its behavior to the current State object.
        public void Request()
        {
            _state.Handle(this);
        }

        public IState GetCurrentState()
        {
            return _state;
        }

        public List<string> GetStateHistory()
        {
            return new List<string>(_stateHistory);
        }
    }
}
