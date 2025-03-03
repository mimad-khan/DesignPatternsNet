namespace DesignPatternsNet.Behavioral.Iterator
{
    /// <summary>
    /// The Iterator interface declares the operations required for traversing a
    /// collection: fetching the next element, retrieving the current position, etc.
    /// </summary>
    public interface IIterator<T>
    {
        // Return the current element
        T Current();
        
        // Return the current element and move forward to next element
        T Next();
        
        // Return whether we've reached the end of the collection
        bool HasNext();
        
        // Rewind the Iterator to the first element
        void Reset();
    }
}
