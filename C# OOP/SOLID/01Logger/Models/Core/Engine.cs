using _01Logger.Models.Common;
using _01Logger.Models.Contracts;
using _01Logger.Models.Core.Contracts;
using _01Logger.Models.Enumerations;
using _01Logger.Models.Errors;
using _01Logger.Models.Factories;
using _01Logger.Models.IOManagment;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace _01Logger.Models.Core
{
    public class Engine : IEngine
    {
        private readonly Ilogger logger;
        private readonly IReader reader;
        private readonly IWriter writer;
 

      
        public Engine(Ilogger logger, IReader reader, IWriter writer) 
        {
            this.writer = writer;
            this.reader = reader;
            this.logger = logger;
        }
        public void Run()
        {
            string command;
            while((command = this.reader.ReadLine()) != "END")
            {
                string[] errorArgs = command.Split('|').ToArray();

                string levelStr = errorArgs[0];
                string dateTimeStr = errorArgs[1];
                string message = errorArgs[2];

                
                bool isLevelValid = Enum.TryParse(typeof(Level),
                    levelStr, true, out object levelObj);

                if (!isLevelValid)
                {
                    this.writer.WriteLine(GlobalConstants.InvalidLevelType);
                    continue;
                }

                Level level = (Level)levelObj;
                bool isDateTimeValid = DateTime.TryParseExact(dateTimeStr, GlobalConstants.DateTimeFormat, CultureInfo
                    .InvariantCulture, DateTimeStyles.None, out DateTime dateTime);
                if (!isDateTimeValid)
                {
                    throw new InvalidOperationException(GlobalConstants.InvalidDateTimeFormat);
                    continue;
                }

                IError error = new Error(dateTime, message, level);
                this.logger.Log(error);
            }

            this.writer.WriteLine(this.logger.ToString());
        }
    }
}
