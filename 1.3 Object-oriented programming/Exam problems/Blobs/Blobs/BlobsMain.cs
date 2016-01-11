namespace Blobs
{
    using Interfaces;
    using Core;

    public class BlobsMain
    {
        static void Main(string[] args)
        {
            IEngine engine = new BlobsEngine();
            engine.Run();
        }
    }
}
