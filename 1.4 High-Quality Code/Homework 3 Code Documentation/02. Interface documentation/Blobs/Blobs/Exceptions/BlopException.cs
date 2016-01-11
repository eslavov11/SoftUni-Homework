namespace Blobs.Exceptions
{
    using System;

    public class BlopException : ApplicationException
    {
        public BlopException(string msg)
            : base(msg)
        {
        }
    }
}
