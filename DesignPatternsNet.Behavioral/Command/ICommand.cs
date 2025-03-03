namespace DesignPatternsNet.Behavioral.Command
{
    /// <summary>
    /// The Command interface declares a method for executing a command.
    /// </summary>
    public interface ICommand
    {
        void Execute();
        void Undo();
        string GetDescription();
    }
}
