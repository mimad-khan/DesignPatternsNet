namespace DesignPatternsNet.Behavioral.Mediator
{
    /// <summary>
    /// The Mediator interface declares a method used by components to notify the
    /// mediator about various events. The Mediator may react to these events and
    /// pass the execution to other components.
    /// </summary>
    public interface IMediator
    {
        void Notify(object sender, string @event);
    }
}
