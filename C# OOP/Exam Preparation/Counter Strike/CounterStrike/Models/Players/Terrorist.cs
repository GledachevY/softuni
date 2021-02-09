using CounterStrike.Models.Guns.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public class Terrorist : Player
    {
        public Terrorist(string userName, int helath, int armout, IGun gun) 
            : base(userName, helath, armout, gun)
        {
        }
    }
}
