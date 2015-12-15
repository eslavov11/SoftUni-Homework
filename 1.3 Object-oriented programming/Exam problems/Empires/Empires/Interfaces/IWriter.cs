namespace Empires.Interfaces
{
    public interface IWriter
    {
        void WriteLine(string output);

        void WriteLine(string format, params object[] args);
    }
}
