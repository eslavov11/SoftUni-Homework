namespace TravelAgency.Interfaces
{
    public interface IWriter
    {
        void Write(object arg);

        void WriteLine();

        void WriteLine(object arg);

        void WriteLine(string format, params object[] args);
    }
}
