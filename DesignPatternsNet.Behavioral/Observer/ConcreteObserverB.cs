using System;

namespace DesignPatternsNet.Behavioral.Observer
{
    /// <summary>
    /// Concrete Observers react to the updates issued by the Subject they had been
    /// attached to.
    /// </summary>
    public class ConcreteObserverB : IObserver
    {
        public string Name { get; }
        public int LastState { get; private set; }
        public string LastReaction { get; private set; } = string.Empty;

        public ConcreteObserverB(string name)
        {
            Name = name;
        }

        public void Update(ISubject subject)
        {
            if (subject is Subject concreteSubject)
            {
                LastState = concreteSubject.State;
                
                if (concreteSubject.State == 0)
                {
                    LastReaction = $"ConcreteObserverB: {Name} reacted to the event: State is zero";
                }
                else if (concreteSubject.State % 2 == 0)
                {
                    LastReaction = $"ConcreteObserverB: {Name} reacted to the event: State is even";
                }
                else
                {
                    LastReaction = $"ConcreteObserverB: {Name} reacted to the event: State is odd";
                }
            }
        }
    }
}
