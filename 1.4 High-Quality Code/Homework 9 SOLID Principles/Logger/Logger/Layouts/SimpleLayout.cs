namespace Logger
{
    using System;
    using Interfaces;

    /// <summary>
    /// Defines the format "<date-time> - <report level> - <message>"
    /// </summary>
    public class SimpleLayout : ILayout
    {
        private const string LogSimpleFormat = "{0} - {1} - {2}";

        /// <summary>
        /// Returns the default simple layout message format - current date time,
        /// report level, message.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string LayoutFormat(string type, string message)
        {
            var formattedLog = string.Format(
                LogSimpleFormat + 
                Environment.NewLine,
                DateTime.Now,
                type,
                message);

            return formattedLog;
        }
    }
}
