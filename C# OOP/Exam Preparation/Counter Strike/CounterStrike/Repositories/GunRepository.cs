using CounterStrike.Models.Guns;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CounterStrike.Models.Guns.Contracts;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private ICollection<IGun> models;

        public GunRepository()
        {
            models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models {

            get
            {
                return (IReadOnlyCollection<IGun>)models;
            }
        }

        public void Add(IGun model)
        {
            if(model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }
            models.Add(model);
        }

        public IGun FindByName(string name)
        {

            IGun gun = models.FirstOrDefault(n => n.Name == name);
            if(gun == null)
            {
                throw new ArgumentException("Gun cannot be found");
            }
            else
            {
                return gun;
            }
        }

        public bool Remove(IGun model)
        {
            if (models.Contains(model))
            {
                models.Remove(model);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
