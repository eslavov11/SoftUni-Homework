namespace Methods.Interfaces
{
    public interface IUserInterface
    {
        string ReadLine();

        void WriteLine(object args);

        void WriteLine(string format, params object[] args);
    }
}
