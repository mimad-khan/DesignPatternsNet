namespace DesignPatternsNet.Behavioral.Iterator
{
    /// <summary>
    /// The Collection interface declares one or multiple methods for getting
    /// iterators compatible with the collection.
    /// </summary>
    public interface ICollection<T>
    {
        IIterator<T> CreateIterator();
    }
}
