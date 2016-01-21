namespace Logger
{
    using Interfaces;

    /// <summary>
    /// Class which is used to log messages. Calls each of its appenders when
    /// something needs to be logged. 
    /// </summary>
    public class Logger : ILogger
    {
        public Logger(IDataAppender dataAdapter)
        {
            this.DataAppender = dataAdapter;
        }

        public IDataAppender DataAppender { get; private set; }

        public void Info(string message)
        {
            this.LogMessage(message, System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void Warn(string message)
        {
            this.LogMessage(message, System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void Error(string message)
        {
            this.LogMessage(message, System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void Critical(string message)
        {
            this.LogMessage(message, System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void Fatal(string message)
        {
            this.LogMessage(message, System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void LogMessage(string message, string type)
        {
            this.DataAppender.Append(type, message);
        }
    }
}
