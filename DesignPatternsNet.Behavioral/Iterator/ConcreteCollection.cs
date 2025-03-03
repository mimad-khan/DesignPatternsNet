using System.Collections.Generic;

namespace DesignPatternsNet.Behavioral.Iterator
{
    /// <summary>
    /// Concrete Collections implement various iterators that can traverse the
    /// collection in different ways.
    /// </summary>
    public class ConcreteCollection<T> : ICollection<T>
    {
        private readonly List<T> _items = new List<T>();

        public void AddItem(T item)
        {
            _items.Add(item);
        }

        public List<T> GetItems()
        {
            return _items;
        }

        public int Count => _items.Count;

        public T this[int index] => _items[index];

        public IIterator<T> CreateIterator()
        {
            return new ConcreteIterator<T>(this);
        }

        public IIterator<T> CreateReverseIterator()
        {
            return new ConcreteReverseIterator<T>(this);
        }
    }
}
