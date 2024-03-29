﻿namespace LoggerLibrary
{
    using Appenders;
    using Appenders.Contracts;
    using Layouts;
    using Layouts.Contracts;
    using Loggers.Enums;
    using Loggers;
    using Loggers.Contracts;

    public class Startup
    {
        public static void Main()
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);
            IAppender appender = new FileAppender(simpleLayout, new LogFile());

            consoleAppender.ReportLevel = ReportLevel.Warning;
            appender.ReportLevel = ReportLevel.Warning;

            var logger = new Logger(consoleAppender);

            logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");

        }
    }
}
