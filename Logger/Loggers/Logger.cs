namespace LoggerLibrary.Loggers
{
    using System;

    using Appenders.Contracts;
    using Loggers.Enums;
    using Loggers.Contracts;

    /// <summary>
    /// hold methods for various kinds of logging 
    /// </summary>

    public class Logger : ILogger
    {
        private IAppender consoleAappender;
        private IAppender fileAappender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAappender = consoleAppender;
        }

        public Logger(IAppender consoleAppender, IAppender fileAappender)
                : this(consoleAppender)
        {
            this.fileAappender = fileAappender;
        }

        public void Info(string dateTime, string infoMessage)
        {
            Append(dateTime, ReportLevel.Info, infoMessage);
        }

        public void Warning(string dateTime, string warningMessage)
        {
            Append(dateTime, ReportLevel.Warning, warningMessage);
        }

        public void Error(string dateTime, string errorMessage)
        {
            Append(dateTime, ReportLevel.Error, errorMessage);
        }

        public void Critical(string dateTime, string criticalMessage)
        {
            Append(dateTime, ReportLevel.Critical, criticalMessage);
        }

        public void Fatal(string dateTime, string fatalMessage)
        {
            Append(dateTime, ReportLevel.Fatal, fatalMessage);
        }
        
        private void Append(string dateTime, ReportLevel reportLevel, string criticalMessage)
        {
            consoleAappender?.Append(dateTime, reportLevel, criticalMessage);

            fileAappender?.Append(dateTime, reportLevel, criticalMessage);
        }
    }
}
