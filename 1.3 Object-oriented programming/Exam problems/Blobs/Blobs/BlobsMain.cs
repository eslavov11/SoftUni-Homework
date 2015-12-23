namespace Blobs
{
    using Blops.Interfaces;
    using Blops.Core;

    public class BlobsMain
    {
        static void Main(string[] args)
        {
            IEngine engine = new BlobsEngine();
            engine.Run();
        }
    }
}
