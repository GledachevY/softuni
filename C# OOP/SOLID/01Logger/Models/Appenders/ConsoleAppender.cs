using _01Logger.Models.Common;
using _01Logger.Models.Contracts;
using _01Logger.Models.Enumerations;
using _01Logger.Models.IOManagment;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01Logger.Models.Appenders
{
    public class ConsoleAppender : Appender
    {
        private readonly IWriter writer;

        public ConsoleAppender(ILayout layout, Level level)
            : base(layout, level)
        {
            this.writer = new ConsoleWriter();
        }
       
        public override void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formatedString = string.Format(format,
                dateTime.ToString(GlobalConstants.DateTimeFormat),
                level.ToString(),
                message);

            this.writer.WriteLine(formatedString);
            this.messagesAppend++;
        }
        
    }
}
