namespace Blobs.Interfaces
{
    /// <summary>
    /// Interface, which consists of Execute method.
    /// </summary>
    public interface ICommandExecutor
    {
        string Execute(ICommand command);
    }
}
