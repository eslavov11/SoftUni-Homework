namespace DirectoryTraversal.Interfaces
{
    public interface IDirectoryPovider
    {
        string[] GetDirectories(string currentDirectory);
    }
}
