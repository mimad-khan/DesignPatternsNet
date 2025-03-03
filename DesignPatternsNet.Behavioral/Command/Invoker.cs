using System.Collections.Generic;

namespace DesignPatternsNet.Behavioral.Command
{
    /// <summary>
    /// The Invoker is associated with one or several commands. It sends a request
    /// to the command.
    /// </summary>
    public class Invoker
    {
        private readonly Stack<ICommand> _history = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            // Execute the command
            command.Execute();
            
            // Add to history for undo functionality
            _history.Push(command);
        }

        public bool CanUndo()
        {
            return _history.Count > 0;
        }

        public ICommand Undo()
        {
            if (!CanUndo())
            {
                return null;
            }

            var command = _history.Pop();
            command.Undo();
            return command;
        }

        public List<string> GetCommandHistory()
        {
            var history = new List<string>();
            foreach (var command in _history)
            {
                history.Add(command.GetDescription());
            }
            return history;
        }
    }
}
