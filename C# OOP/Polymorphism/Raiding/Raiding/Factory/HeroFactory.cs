using Softriding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Softriding.Factory
{
    public class HeroFactory
    {
        public BaseHero Create(string strType, string name)
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            bool isHeroValid = assembly.GetTypes().Select(b => b.Name).Contains(strType);
            if (!isHeroValid  )
            {
                throw new InvalidOperationException(string.Format("Invalid hero!"));
            }
           
                Type type = assembly.GetTypes().FirstOrDefault(a => a.Name == strType);


                object[] ctorParams = new object[] { name };

                BaseHero hero = (BaseHero)Activator.CreateInstance(type, ctorParams);
                return hero;
            

        }
    }
}
