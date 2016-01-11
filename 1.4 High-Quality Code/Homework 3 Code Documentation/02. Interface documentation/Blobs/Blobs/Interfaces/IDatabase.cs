namespace Blobs.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// The project's main database which holds all blobs
    /// </summary>
    public interface IDatabase
    {
        ICollection<IBlob> Blobs { get; } 
    }
}
