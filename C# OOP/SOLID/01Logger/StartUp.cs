using _01Logger.Models;
using _01Logger.Models.Common;
using _01Logger.Models.Contracts;
using _01Logger.Models.Core;
using _01Logger.Models.Core.Contracts;
using _01Logger.Models.Enumerations;
using _01Logger.Models.Factories;
using _01Logger.Models.Files;
using _01Logger.Models.IOManagment;
using _01Logger.Models.PathManagment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01Logger
{
    public class StartUp
    {
       
        


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory();

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IPathManager pathManager = new PathManager("logs", "logs.txt");

            IFile file = new LogFile(pathManager);
            Ilogger logger = SetUpLogger(n, reader, writer, file, layoutFactory, appenderFactory);

            IEngine engine = new Engine(logger, reader, writer);
            engine.Run();

        }

        private static Ilogger SetUpLogger(int count, IReader reader, IWriter writer,IFile file, LayoutFactory layoutFactory,
            AppenderFactory appenderFactory)
        {
            ICollection<IAppender> appenders = new HashSet<IAppender>();

            for (int i = 0; i < count; i++)
            {
                string[] args = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string appenderType = args[0];
                string layoutType = args[1];

                bool hasError = false;
                Level level = ParseLevel(args, writer, ref hasError);
                if (hasError)
                {
                    continue;
                }
                try
                {
                    ILayout layout = layoutFactory.CreateLayout(layoutType);
                    IAppender appender = appenderFactory.CreateAppender(appenderType, layout, level,
                        file);
                    appenders.Add(appender);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                    
                }
            }

            Ilogger logger = new Logger(appenders);
            return logger;
        }

        private static Level ParseLevel(string[] levelString, IWriter writer, ref bool hasError)
        {
            Level appenderLevel = Level.INFO;

            if (levelString.Length == 3)
            {
                bool isEnumValid = Enum.TryParse(typeof(Level), levelString[2], true, out object enumPArsed);

                if (!isEnumValid)
                {
                    writer.WriteLine(GlobalConstants.InvalidLevelType);
                    hasError = true;
                }

                appenderLevel = (Level)enumPArsed;
            }
            return appenderLevel;
        }
    }
}
