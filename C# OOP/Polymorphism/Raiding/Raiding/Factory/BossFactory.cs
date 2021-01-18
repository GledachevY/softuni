using Softriding.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Softriding.Factory
{
   public class BossFactory
    {
        public Boss Create(int power)
        {
            Boss boss = new Boss(power);
            return boss;
        }
    }
}
