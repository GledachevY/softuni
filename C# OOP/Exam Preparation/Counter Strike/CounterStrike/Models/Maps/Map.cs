using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private List<IPlayer> CounterTerrorist;
        private List<IPlayer> Terrorist;

        public Map()
        {
            this.CounterTerrorist = new List<IPlayer>();
            this.Terrorist = new List<IPlayer>();
        }

        public string Start(ICollection<IPlayer> players)
        {
            foreach (var sortingplayers in players)
            {
                if (sortingplayers is Terrorist)
                {
                    Terrorist.Add(sortingplayers);
                }
                else if (sortingplayers is CounterTerrorist)
                {
                    CounterTerrorist.Add(sortingplayers);
                }
            }

            while (IsTeamAlive(Terrorist) && IsTeamAlive(CounterTerrorist))
            {
                AttackTeam(Terrorist, CounterTerrorist);
                AttackTeam(CounterTerrorist, Terrorist);
            }

            if (IsTeamAlive(CounterTerrorist))
            {
                return "Counter Terrorist wins!";
            }
            else if(IsTeamAlive(Terrorist))
            {
                return "Terrorist wins!";
            }
            else
            {
                return "Something Wrong";
            }
            
        }

        private bool IsTeamAlive(List<IPlayer> players)
        {
            return players.Any(p => p.IsAlive);
        }

        private void AttackTeam(List<IPlayer> attack, List<IPlayer> deffence)
        {
            foreach (var attacker in attack)
            {
               // if (!attacker.IsAlive) continue;
                foreach (var deffender in deffence)
                {
                    if (deffender.IsAlive)
                    {
                        deffender.TakeDamage(attacker.Gun.Fire());
                    }
                }
            }
        }

       
    }
}
