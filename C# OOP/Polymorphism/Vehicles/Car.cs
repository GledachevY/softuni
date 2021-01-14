using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fQuantity, double fConsumption) :
            base(fQuantity, fConsumption)
        {

        }
        public override double FuelConsumption { get => base.FuelConsumption + 0.9; set => base.FuelConsumption = value; }
    }
}
