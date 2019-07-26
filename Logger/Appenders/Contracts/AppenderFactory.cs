namespace LoggerLibrary.Appenders.Contracts
{
    using System;

    using Layouts.Contracts;
    using Loggers;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeAsLower = type.ToLower();

            switch (typeAsLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                    break;

                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                    break;

                default:
                    throw new ArgumentException("Invalid append type!");
            }
        }
    }
}
