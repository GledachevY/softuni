using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string _name;
        private int _bulletCount;

        public Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
        }

        public string Name {

            get
            {
                return this._name;
            }
            private set
            {
                if(value.Length == 0 || _name == string.Empty)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }
                this._name = value;
            }
        }

        public int BulletsCount
        {

            get
            {
                return this._bulletCount;
            }
           protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
                }
                this._bulletCount = value;
            }
        }

        abstract protected int FireRate { get;  }
        public  int Fire()
        {
            if (BulletsCount - FireRate >= 0)
            {
                BulletsCount -= FireRate;
                return this.FireRate;
            }
            else
            {
                int resultBullets = this.BulletsCount;
                BulletsCount = 0;
                return resultBullets;
            }
        }
        
    }
}
