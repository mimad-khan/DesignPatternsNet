namespace DesignPatternsNet.Behavioral.Command
{
    /// <summary>
    /// Concrete Commands implement various kinds of requests. A concrete command
    /// isn't supposed to perform the work on its own, but rather to pass the call
    /// to one of the business logic objects (receivers).
    /// </summary>
    public class AddItemCommand : ICommand
    {
        private readonly Receiver _receiver;
        private readonly string _item;

        public AddItemCommand(Receiver receiver, string item)
        {
            _receiver = receiver;
            _item = item;
        }

        // Commands can delegate to any methods of a receiver.
        public void Execute()
        {
            _receiver.AddItem(_item);
        }

        public void Undo()
        {
            _receiver.RemoveItem(_item);
        }

        public string GetDescription()
        {
            return $"Add item: {_item}";
        }
    }
}
