using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _01Logger.Models.IOManagment
{
    public class FileWriter : IWriter
    {
        public FileWriter(string filepath)
        {
            this.FilePath = filepath;
        }

        public string FilePath { get; }
        public void Write(string text)
        {
            File.WriteAllText(this.FilePath, text);
        }

        public void WriteLine(string text)
        {
            File.AppendAllText(this.FilePath, text + Environment.NewLine);
        }
    }
}
