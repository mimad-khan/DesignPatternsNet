using System.Collections.Generic;

namespace DesignPatternsNet.Behavioral.Mediator
{
    /// <summary>
    /// Concrete Mediators implement cooperative behavior by coordinating several
    /// components.
    /// </summary>
    public class ConcreteMediator : IMediator
    {
        private Component1 _component1;
        private Component2 _component2;
        private readonly List<string> _eventLog = new List<string>();

        public ConcreteMediator(Component1 component1, Component2 component2)
        {
            _component1 = component1;
            _component1.SetMediator(this);
            
            _component2 = component2;
            _component2.SetMediator(this);
        }

        public void Notify(object sender, string @event)
        {
            var logEntry = $"Mediator received event '{@event}' from {sender.GetType().Name}";
            _eventLog.Add(logEntry);

            if (@event == "A")
            {
                // Component1 triggered event A, notify Component2
                var response = _component2.ReceiveMessage("Event A occurred");
                _eventLog.Add(response);
            }
            else if (@event == "B")
            {
                // Component1 triggered event B, notify Component2
                var response = _component2.ReceiveMessage("Event B occurred");
                _eventLog.Add(response);
            }
            else if (@event == "C")
            {
                // Component2 triggered event C, notify Component1
                var response = _component1.ReceiveMessage("Event C occurred");
                _eventLog.Add(response);
            }
            else if (@event == "D")
            {
                // Component2 triggered event D, notify Component1
                var response = _component1.ReceiveMessage("Event D occurred");
                _eventLog.Add(response);
            }
        }

        public List<string> GetEventLog()
        {
            return new List<string>(_eventLog);
        }
    }
}
