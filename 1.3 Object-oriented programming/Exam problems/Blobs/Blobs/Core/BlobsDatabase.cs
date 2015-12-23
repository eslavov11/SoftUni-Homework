namespace Blops.Core
{
    using System.Collections.Generic;
    using Interfaces;

    public class BlobsDatabase : IDatabase
    {
        public BlobsDatabase()
        {
            this.Blobs = new List<IBlob>();
        }

        public ICollection<IBlob> Blobs { get; }
    }
}
