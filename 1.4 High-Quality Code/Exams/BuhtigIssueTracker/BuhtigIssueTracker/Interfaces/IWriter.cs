namespace BuhtigIssueTracker.Interfaces
{
    public interface IWriter
    {
        void WriteLine();

        void Write(object arg);

        void WriteLine(object arg);

        void WriteLine(string obj, params object[] args);
    }
}
