using System;

namespace DesignPatternsNet.Behavioral.Observer
{
    /// <summary>
    /// Concrete Observers react to the updates issued by the Subject they had been
    /// attached to.
    /// </summary>
    public class ConcreteObserverA : IObserver
    {
        public string Name { get; }
        public int LastState { get; private set; }
        public string LastReaction { get; private set; } = string.Empty;

        public ConcreteObserverA(string name)
        {
            Name = name;
        }

        public void Update(ISubject subject)
        {
            if (subject is Subject concreteSubject)
            {
                LastState = concreteSubject.State;
                
                if (concreteSubject.State < 3)
                {
                    LastReaction = $"ConcreteObserverA: {Name} reacted to the event: State is less than 3";
                }
                else
                {
                    LastReaction = $"ConcreteObserverA: {Name} reacted to the event: State is 3 or greater";
                }
            }
        }
    }
}
