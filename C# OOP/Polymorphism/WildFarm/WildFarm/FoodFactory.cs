using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WildFarm.Models.Foods;


namespace WildFarm
{
    public class FoodFactory
    {
        public Food CreateFood(string strType, int quantity)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == strType);
            object[] ctorParams = new object[] { quantity };
            Food food = (Food)Activator.CreateInstance(type, ctorParams);
            return food;
        }
    }
}
