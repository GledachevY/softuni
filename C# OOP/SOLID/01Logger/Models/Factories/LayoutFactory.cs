using _01Logger.Models.Common;
using _01Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _01Logger.Models.Factories
{
    public class LayoutFactory
    {
        public LayoutFactory()
        {

        }

        public ILayout CreateLayout(string layouTypeStr)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type layoutType = assembly.GetTypes().FirstOrDefault(s => s.Name.Equals(layouTypeStr, StringComparison
                .InvariantCultureIgnoreCase));

            if(layoutType == null)
            {
                throw new InvalidOperationException(GlobalConstants.InvalidLayotType);

            }

            object[] ctorArgs = new object[] { };
            ILayout layout =
                (ILayout)Activator.CreateInstance(layoutType, ctorArgs);
            return layout;
        }
    }
}
