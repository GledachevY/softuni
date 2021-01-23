using _01Logger.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01Logger.Models.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }
        string Message { get; }
        Level Level { get; }
    }
}
