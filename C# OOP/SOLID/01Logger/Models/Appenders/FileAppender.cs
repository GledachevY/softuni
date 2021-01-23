using _01Logger.Models.Contracts;
using _01Logger.Models.Enumerations;
using _01Logger.Models.IOManagment;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01Logger.Models.Appenders
{
    public class FileAppender : Appender
    {
        private readonly IWriter writer;
        public FileAppender(ILayout layout, Level level, IFile file)
            :base(layout, level)
        {
            this.File = file;
            this.writer = new FileWriter(this.File.Path);
        }
      
        public IFile File { get; }

        public override void Append(IError error)
        {
            string formattedMessage = this.File.Write(this.Layout, error);
            this.writer.WriteLine(formattedMessage);
            this.messagesAppend++;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size {this.File.Size}";
        }
    }
}
