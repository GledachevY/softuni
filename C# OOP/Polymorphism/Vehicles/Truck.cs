using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fQuantity, double fConsumption) :
            base ( fQuantity, fConsumption)
        {

        }

        public override double FuelConsumption { get => base.FuelConsumption + 1.6; set => base.FuelConsumption = value; }
        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters * 0.95;
        }
        
    }

}
