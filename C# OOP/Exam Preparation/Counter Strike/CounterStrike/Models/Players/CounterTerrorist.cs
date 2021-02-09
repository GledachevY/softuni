using CounterStrike.Models.Guns.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public class CounterTerrorist : Player
    {
        public CounterTerrorist(string userName, int helath, int armout, IGun gun) 
            : base(userName, helath, armout, gun)
        {
        }
    }
}
