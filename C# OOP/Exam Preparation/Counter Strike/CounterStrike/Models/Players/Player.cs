using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public class Player : IPlayer
    {
        private string _username;
        private int _helath;
        private int _armor;
        private IGun _gun;

        public Player(string userName, int helath, int armout, IGun gun)
        {
            this.Username = userName;
            this.Health = helath;
            this.Armor = armout;
            this.Gun = gun;
        }

        public string Username
        {

            get
            {
                return _username;
            }
            private set
            {
                if (value.Length == 0 || value == string.Empty)
                {
                    throw new Exception(ExceptionMessages.InvalidPlayerName);
                }
               this._username = value;
            }
        }

        public int Health
        {

            get
            {
                return _helath;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }
               
                this._helath = value;
            }
        }

        public int Armor
        {

            get
            {
                return _armor;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }
                this._armor = value;
            }
        }
        public string AboutMe()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {this.Username}");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armor: {this.Armor}");
            sb.AppendLine($"Gun: {this.Gun.Name}");

            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {this.Username}");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armor: {this.Armor}");
            sb.AppendLine($"Gun: {this.Gun.Name}");

            return sb.ToString().Trim();
        }
        public IGun Gun
        {
            get
            {
                return _gun;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }
                this._gun = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                return this.Health > 0;
            }
            
        }

        public void TakeDamage(int points)
        {
            if (this._armor - points >= 0)
            {
                this._armor -= points;
                return;
            }else if(this._armor > 0)
            {
                points -= this._armor;
                this._armor = 0;
            }

            
            if(this.Health - points < 0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health -= points;
            }

        }
    }
}
