using _01Logger.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01Logger.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get;  }
        Level Level { get; }
        void Append(IError error);
    }
}
