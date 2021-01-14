using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Core.Contracts;
using Vehicles.Factories;
using System.Linq;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly VehicleFactory vehicleFactory;
        public Engine()
        {
            vehicleFactory = new VehicleFactory();
        }
        public void Run()
        {
            Vehicle car = this.ProcessVehicleInfo();
            Vehicle truck = this.ProcessVehicleInfo();
            double numOfLines = double.Parse(Console.ReadLine());
            for(int  i = 0; i < numOfLines; i++)
            {
                string[] input = Console.ReadLine().Split();
                string action = input[0];
                string typeOfVehicle = input[1];
                double number = double.Parse(input[2]);
                try
                {
                    if (action == "Drive")
                    {
                        if (typeOfVehicle == "Car")
                        {
                            this.Drive(car, number);
                        }
                        else if (typeOfVehicle == "Truck")
                        {
                            this.Drive(truck, number);
                        }
                    }
                    else if (action == "Refuel")
                    {
                        if (typeOfVehicle == "Car")
                        {
                            this.Refuel(car, number);
                        }
                        else if (typeOfVehicle == "Truck")
                        {
                            this.Refuel(truck, number);
                        }
                    }
                }catch(InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
        private void Refuel(Vehicle vehicle, double liters)
        {
            vehicle.Refuel(liters);
        }

        public void Drive(Vehicle vehicle, double kilometers)
        {
            Console.WriteLine(vehicle.Drive(kilometers));
        }
        private Vehicle ProcessVehicleInfo()
        {
            string[] input = Console.ReadLine().Split();
            string vehicleType = input[0];
            double fuelQuantity = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);

                Vehicle currvehicle = this.vehicleFactory.CreateVehicle(vehicleType, fuelQuantity, fuelConsumption);
            return currvehicle;
        }
        
    }
}
