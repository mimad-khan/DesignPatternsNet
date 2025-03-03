namespace DesignPatternsNet.Behavioral.Iterator
{
    /// <summary>
    /// Concrete Iterators implement various traversal algorithms. These classes
    /// store the current traversal position at all times.
    /// </summary>
    public class ConcreteReverseIterator<T> : IIterator<T>
    {
        private readonly ConcreteCollection<T> _collection;
        private int _position;

        public ConcreteReverseIterator(ConcreteCollection<T> collection)
        {
            _collection = collection;
            _position = collection.Count - 1;
        }

        public T Current()
        {
            return _collection[_position];
        }

        public T Next()
        {
            var item = _collection[_position];
            _position--;
            return item;
        }

        public bool HasNext()
        {
            return _position >= 0;
        }

        public void Reset()
        {
            _position = _collection.Count - 1;
        }
    }
}
