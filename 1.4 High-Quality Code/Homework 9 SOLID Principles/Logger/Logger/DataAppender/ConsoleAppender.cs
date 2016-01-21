namespace Logger.DataAppender
{
    using static System.Console;
    using Interfaces;

    /// <summary>
    /// Appends a log to the console using the provided layout.
    /// </summary>
    public class ConsoleAppender : DataAppender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string type, string message)
        {
            WriteLine(this.Layout.LayoutFormat(type, message));
        }
    }
}
