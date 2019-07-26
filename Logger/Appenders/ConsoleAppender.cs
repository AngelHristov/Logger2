namespace LoggerLibrary.Appenders
{
    using System;

    using Appenders.Contracts;
    using Layouts.Contracts;
    using Loggers.Enums;

    /// <summary>
    /// appends a log to the console, using the provided layout
    /// </summary>

    public class ConsoleAppender : IAppender
    {
        private ILayout layout;
        
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public ILayout Layout
        {
            get => this.layout;
            set => this.layout = value;
        }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
            }           
        }
    }
}
