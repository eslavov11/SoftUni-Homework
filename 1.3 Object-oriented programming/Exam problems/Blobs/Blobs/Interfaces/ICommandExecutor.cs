namespace Blops.Interfaces
{
    public interface ICommandExecutor
    {
        string Execute(ICommand command);
    }
}
