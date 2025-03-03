namespace DesignPatternsNet.Behavioral.Command
{
    /// <summary>
    /// Concrete Commands implement various kinds of requests. A concrete command
    /// isn't supposed to perform the work on its own, but rather to pass the call
    /// to one of the business logic objects (receivers).
    /// </summary>
    public class RemoveItemCommand : ICommand
    {
        private readonly Receiver _receiver;
        private readonly string _item;
        private bool _wasRemoved;

        public RemoveItemCommand(Receiver receiver, string item)
        {
            _receiver = receiver;
            _item = item;
            _wasRemoved = false;
        }

        // Commands can delegate to any methods of a receiver.
        public void Execute()
        {
            // Check if the item exists before removing
            var items = _receiver.GetItems();
            _wasRemoved = items.Contains(_item);
            
            if (_wasRemoved)
            {
                _receiver.RemoveItem(_item);
            }
        }

        public void Undo()
        {
            // Only add the item back if it was actually removed
            if (_wasRemoved)
            {
                _receiver.AddItem(_item);
                _wasRemoved = false;
            }
        }

        public string GetDescription()
        {
            return $"Remove item: {_item}";
        }
    }
}
