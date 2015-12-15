namespace Empires.Interfaces
{
    public interface ICommandExecutor
    {
        string ExecuteCommand(ICommand command);
    }
}
