namespace Matrix.Interfaces
{
    public interface IUserInterface
    {
        void WriteLine();

        void WriteLine(string arg);

        void WriteLine(string obj, params object[] args);

        void Write(string obj, params object[] args);

        string ReadLine();
    }
}
