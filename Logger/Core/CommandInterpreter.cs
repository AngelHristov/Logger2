namespace LoggerLibrary.Core
{
    using System;
    using System.Collections.Generic;
    
    using Core.Contracts;
    using Appenders.Contracts;
    using Loggers.Enums;
    using Layouts.Contracts;
    using Layouts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutfactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutfactory = new LayoutFactory()
        }

        public void AddAppender(string[] args)
        {
            string type = args[0];
            string layoutType = args[1];

            ReportLevel reportLevel = ReportLevel.Info;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2]);
            }

            ILayout layout = this.layoutfactory.CreateLayout(layoutType);

            IAppender appender = this.appenderFactory.CreateAppender(type, layout);

            appender.ReportLevel = reportLevel;

            appenders.Add(appender);
        }

        public void AddReport(string[] args)
        {
            string reportType = args[0];
            string dateTime = args[1];
            string message = args[2];
        }

        public void PrintInfo()
        {
            throw new System.NotImplementedException();
        }
    }
}
