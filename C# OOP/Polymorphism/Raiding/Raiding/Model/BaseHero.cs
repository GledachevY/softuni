using Softriding.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Softriding.Model
{
    public abstract class BaseHero : ICastableAbility
    {
        public BaseHero(string name )
        {
            this.Name = name;

           // Console.WriteLine(this.CastAbility());
        }
        public virtual int Power { get; private set; }
        public string Name { get; }
        public abstract string CastAbility();
        
    }
}
