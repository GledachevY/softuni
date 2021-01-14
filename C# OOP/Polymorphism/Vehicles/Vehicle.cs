using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Contracts;

namespace Vehicles
{
   public abstract class Vehicle : IRefuelable, IDrive
    {
        
        public Vehicle(double fQuantity, double fCOnsumption)
        {
            this.FuelQuantity = fQuantity;
            this.FuelConsumption = fCOnsumption;
        }
        public double FuelQuantity { get; set; }
        public virtual double FuelConsumption { get; set; }

        public string Drive(double kilometers)
        {
            double fuelNeed = kilometers * this.FuelConsumption;
            if (fuelNeed > this.FuelQuantity)
            {
               throw new InvalidOperationException( string.Format(ExeptionMessage.NotEnougFuel, this.GetType().Name));
            }
            else
            {
                this.FuelQuantity -= fuelNeed;
                return string.Format(ExeptionMessage.SuccesDriven, this.GetType().Name, kilometers);
            }
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
