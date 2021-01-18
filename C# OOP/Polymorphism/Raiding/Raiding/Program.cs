using Softriding.Core;
using Softriding.Core.Contracts;
using System;

namespace Softriding
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
