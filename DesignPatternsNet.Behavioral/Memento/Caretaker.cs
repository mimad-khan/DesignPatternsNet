using System.Collections.Generic;
using System.Linq;

namespace DesignPatternsNet.Behavioral.Memento
{
    /// <summary>
    /// The Caretaker doesn't depend on the Concrete Memento class. Therefore, it
    /// doesn't have access to the originator's state, stored inside the memento. It
    /// works with all mementos via the base Memento interface.
    /// </summary>
    public class Caretaker
    {
        private readonly List<Memento> _mementos = new List<Memento>();
        private readonly Originator _originator;

        public Caretaker(Originator originator)
        {
            _originator = originator;
        }

        public void Backup()
        {
            _mementos.Add(_originator.Save());
        }

        public void Undo()
        {
            if (_mementos.Count == 0)
            {
                return;
            }

            var memento = _mementos.Last();
            _mementos.Remove(memento);

            _originator.Restore(memento);
        }

        public List<string> ShowHistory()
        {
            return _mementos.Select(m => m.GetName()).ToList();
        }

        public int GetHistoryCount()
        {
            return _mementos.Count;
        }
    }
}
