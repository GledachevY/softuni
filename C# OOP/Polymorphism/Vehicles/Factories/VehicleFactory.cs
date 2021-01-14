using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Factories
{
   public class VehicleFactory
    {
        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle;
            if(vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }else
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }
            return vehicle;
        }
    }
}
