using _01Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01Logger.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
