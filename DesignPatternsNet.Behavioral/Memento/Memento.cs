using System;

namespace DesignPatternsNet.Behavioral.Memento
{
    /// <summary>
    /// The Memento class stores the Originator's state.
    /// </summary>
    public class Memento
    {
        private readonly string _state;
        private readonly DateTime _date;

        public Memento(string state)
        {
            _state = state;
            _date = DateTime.Now;
        }

        // The Originator uses this method to restore its state
        public string GetState()
        {
            return _state;
        }

        // The rest of the methods are used by the Caretaker to display metadata
        public string GetName()
        {
            return $"{_date:yyyy-MM-dd HH:mm:ss} / ({_state.Substring(0, Math.Min(10, _state.Length))})...";
        }

        public DateTime GetDate()
        {
            return _date;
        }
    }
}
