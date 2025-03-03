using System.Collections.Generic;

namespace DesignPatternsNet.Behavioral.Command
{
    /// <summary>
    /// Concrete Commands implement various kinds of requests. A concrete command
    /// isn't supposed to perform the work on its own, but rather to pass the call
    /// to one of the business logic objects (receivers).
    /// </summary>
    public class ClearItemsCommand : ICommand
    {
        private readonly Receiver _receiver;
        private List<string> _backupItems;

        public ClearItemsCommand(Receiver receiver)
        {
            _receiver = receiver;
            _backupItems = new List<string>();
        }

        // Commands can delegate to any methods of a receiver.
        public void Execute()
        {
            // Backup items for undo operation
            _backupItems = _receiver.GetItems();
            
            // Clear all items
            _receiver.ClearItems();
        }

        public void Undo()
        {
            // Restore all items from backup
            _receiver.ClearItems();
            foreach (var item in _backupItems)
            {
                _receiver.AddItem(item);
            }
        }

        public string GetDescription()
        {
            return "Clear all items";
        }
    }
}
