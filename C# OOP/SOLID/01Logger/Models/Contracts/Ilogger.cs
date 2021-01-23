using System;
using System.Collections.Generic;
using System.Text;

namespace _01Logger.Models.Contracts
{
    public interface Ilogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Log(IError error);
    }
}
