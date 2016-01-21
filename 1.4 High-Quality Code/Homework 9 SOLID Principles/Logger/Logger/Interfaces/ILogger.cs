namespace Logger.Interfaces
{
    public interface ILogger
    {
        void Info(string message);
        
        void Warn(string message);
        
        void Error(string message);
        
        void Critical(string message);
        
        void Fatal(string message);
    }
}
