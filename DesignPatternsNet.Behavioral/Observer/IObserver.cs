namespace DesignPatternsNet.Behavioral.Observer
{
    /// <summary>
    /// The Observer interface declares the update method, used by subjects.
    /// </summary>
    public interface IObserver
    {
        // Receive update from subject
        void Update(ISubject subject);
    }
}
