using System;
using System.Collections.Generic;
using System.Text;

namespace _01Logger.Models.IOManagment
{
    public interface IWriter
    {
        void Write(string text);

        void WriteLine(string text);
    }
}
