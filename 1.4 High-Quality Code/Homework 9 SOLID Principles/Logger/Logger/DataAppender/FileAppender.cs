namespace Logger.DataAppender
{
    using Interfaces;

    /// <summary>
    /// Sppends a log to a file using the provided layout.
    /// </summary>
    public class FileAppender : DataAppender
    {
        public FileAppender(ILayout layout, string file)
            : base(layout)
        {
            this.File = file;
        }

        public string File { get; }

        public override void Append(string type, string message)
        {
            System.IO.File.AppendAllText(
                this.File, 
                string.Format(this.Layout.LayoutFormat(type, message)));
        }
    }
}
