using System;
using System.Collections.Generic;
using System.Text;

namespace _01Logger.Models.IOManagment
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
