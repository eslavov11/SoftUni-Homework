namespace Exam.Interfaces
{
    public interface IWriter
    {
        void WriteLine(string args);

        void WriteLine(string format, params object[] args);
    }
}
