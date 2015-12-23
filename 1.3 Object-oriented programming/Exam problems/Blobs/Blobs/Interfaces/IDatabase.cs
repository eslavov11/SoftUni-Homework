namespace Blops.Interfaces
{
    using System.Collections.Generic;
    public interface IDatabase
    {
        ICollection<IBlob> Blobs { get; } 
    }
}
