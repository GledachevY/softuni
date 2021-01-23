using _01Logger.Models.Appenders;
using _01Logger.Models.Common;
using _01Logger.Models.Contracts;
using _01Logger.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _01Logger.Models.Factories
{
    public class AppenderFactory
    {
        public AppenderFactory()
        {
           
        }
        public IAppender CreateAppender(string appenderTypeStr, ILayout layout, Level level, IFile file = null)
        {
            IAppender appender;
            if (appenderTypeStr == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderTypeStr == "FileAppender" && file != null)
            {
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidOperationException(GlobalConstants.InvalidAppender);
            }
            return appender;
        }
    }
}
