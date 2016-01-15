namespace Methods.Interfaces
{
    public interface IUserInterface
    {
        string ReadLine();

        void WriteLine(string args);

        void WriteLine(double args);

        void WriteLine(string format, params object[] args);
    }
}
