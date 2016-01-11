namespace Blobs.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Holds name and parameters of an input command
    /// </summary>
    public interface ICommand
    {
        string Name { get; }

        IList<string> Parameters { get; }
    }
}
