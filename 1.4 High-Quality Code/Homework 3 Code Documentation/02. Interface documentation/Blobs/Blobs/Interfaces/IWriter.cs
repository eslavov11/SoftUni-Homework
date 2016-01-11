namespace Blobs.Interfaces
{
    /// <summary>
    /// Interface which holds behavior for writing a line.
    /// </summary>
    public interface IWriter
    {
        void WriteLine(string args);

        void WriteLine(string format, params object[] args);
    }
}
