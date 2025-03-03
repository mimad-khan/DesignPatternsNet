using System.Collections.Generic;

namespace DesignPatternsNet.Behavioral.Command
{
    /// <summary>
    /// The Receiver class contains some important business logic. It knows how to
    /// perform all kinds of operations, associated with carrying out a request. In
    /// fact, any class may serve as a Receiver.
    /// </summary>
    public class Receiver
    {
        private readonly List<string> _items = new List<string>();

        public void AddItem(string item)
        {
            _items.Add(item);
        }

        public void RemoveItem(string item)
        {
            _items.Remove(item);
        }

        public List<string> GetItems()
        {
            return new List<string>(_items);
        }

        public void ClearItems()
        {
            _items.Clear();
        }
    }
}
