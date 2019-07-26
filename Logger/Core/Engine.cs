namespace LoggerLibrary.Core
{
    using System;

    using LoggerLibrary.Core.Contracts;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            int appendersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                this.commandInterpreter.AddAppender(appenderArgs);
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] reportArgs = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                this.commandInterpreter.AddReport(reportArgs);
            }
            this.commandInterpreter.PrintInfo()
        }
    }
}
