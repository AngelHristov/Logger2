namespace LoggerLibrary.Appenders
{
    using System;
    using System.IO;

    using Appenders.Contracts;
    using Layouts.Contracts;
    using LoggerLibrary.Loggers.Enums;
    using Loggers.Contracts;

    /// <summary>
    /// appends a log to a file, using the provided layout
    /// </summary>

    public class FileAppender : IAppender
    {
        private const string LogFilePath = @"..\..\..\log.txt";

        private ILayout layout;
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
        {
            this.Layout = layout;
            this.LogFile = logFile;
        }

        public ILayout Layout
        {
            get => this.layout;
            set => this.layout = value;
        }
        public ILogFile LogFile
        {
            get => logFile;
            set => logFile = value;
        }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {            
            if (this.ReportLevel <= reportLevel)
            {
                string content = string.Format(this.Layout.Format, dateTime, reportLevel, message) +
               Environment.NewLine;

                File.AppendAllText(LogFilePath, content);
            }
        }
    }
}
