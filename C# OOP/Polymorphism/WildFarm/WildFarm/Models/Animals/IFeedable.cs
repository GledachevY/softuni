using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Models.Animals
{
    public interface IFeedable
    {
        void Feed(IFood food);

        int FoodEaten { get; }
        double WeightMultiplyer { get; }

        ICollection<Type> PrefferedFood { get; }
    }
}
