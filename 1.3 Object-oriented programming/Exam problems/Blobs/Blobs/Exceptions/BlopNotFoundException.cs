namespace Blobs.Exceptions
{
    public class BlopNotFoundException : BlopException
    {
        public BlopNotFoundException(string msg)
            : base(msg)
        {
        }
    }
}
