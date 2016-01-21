namespace Logger.Interfaces
{
    public interface IDataAppender
    {
        void Append(string type, string mesage);
    }
}
