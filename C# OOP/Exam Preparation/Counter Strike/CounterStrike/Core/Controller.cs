using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Runtime.ExceptionServices;
using System.Linq;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository gunRepository;
        private PlayerRepository playerRepository;
        private IMap map;
        public Controller()
        {
            gunRepository = new GunRepository();
            playerRepository = new PlayerRepository();
            map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
           


            Assembly assembly = Assembly.GetExecutingAssembly();
            Type typeOfGun = assembly.GetTypes().FirstOrDefault(n => n.Name == type);
            if (type != "Pistol" && type != "Rifle")
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }
            Object[] item = { name, bulletsCount };


            try
            {

                IGun gun = (Gun)Activator.CreateInstance(typeOfGun, item);
                gunRepository.Add((Gun)gun);
                return string.Format(OutputMessages.SuccessfullyAddedGun, gun.Name);
            }
            catch (Exception r)
            {

                throw r.InnerException;
            }
            
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            if (type != "Terrorist" && type != "CounterTerrorist")
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }
            if(gunRepository.FindByName(gunName) == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type typeOfPlayer = assembly.GetTypes().FirstOrDefault(n => n.Name == type);
            IGun gun = gunRepository.FindByName(gunName);
            Object[] item = { username, health, armor, gun};

            try
            {
                IPlayer player = (Player)Activator.CreateInstance(typeOfPlayer, item);
                playerRepository.Add((Player)player);
                return string.Format(OutputMessages.SuccessfullyAddedPlayer, player.Username);
            }
            catch (TargetInvocationException tie)
            {

                throw tie.InnerException;
            }
           
        }

        public string Report()
        {
            var sortedPlayers = playerRepository.Models
                .OrderBy(p => p.GetType().Name)
                .ThenByDescending(p => p.Health)
                .ThenBy(p => p.Username);

            StringBuilder sb = new StringBuilder();
            foreach (Player playerche in sortedPlayers)
            {
                sb.AppendLine(playerche.AboutMe());
            }
            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            Map map = new Map();
           return map.Start(playerRepository.Models.ToList());
        }
    }
}
