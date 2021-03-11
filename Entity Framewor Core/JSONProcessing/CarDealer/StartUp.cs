using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static string ResultDirectoryPath = "../../../Datasets/Results";
        public static void Main(string[] args)
        {
            CarDealerContext db = new CarDealerContext();

            //ResetDatabase(db);

            //string inputJson = File.ReadAllText("../../../Datasets/sales.json");
            //string result = ImportSales(db, inputJson);

            string json = GetCarsWithTheirListOfParts(db);

            if (!Directory.Exists(ResultDirectoryPath))
            {
                Directory.CreateDirectory(ResultDirectoryPath);
            }

            File.WriteAllText(ResultDirectoryPath + "/cars-and-parts.json", json);

           // Console.WriteLine(result);
        }

        private static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Db was deleted.");
            db.Database.EnsureCreated();
            Console.WriteLine("Db was created.");
        }

        // problem 8
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        // problem 9
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            //JsonSerializerSettings settings = new JsonSerializerSettings()
            //{
            //    NullValueHandling = NullValueHandling.Ignore
            //};
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson).Where
                (p => p.SupplierId<= context.Suppliers.Count()).ToArray();
            
            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";
        }

        //problem 10
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson).ToList();

            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            foreach (var carDto in carsDto)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravalledDistance
                };

                foreach (var part in carDto.PartsId.Distinct())
                {
                    var carPart = new PartCar()
                    {
                        PartId = part,
                        Car = car
                    };
                    carParts.Add(carPart);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        // problem 11
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        // problem 12
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        // problem 13
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                 .ThenBy(C => C.IsYoungDriver)
                .Select(c=> new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd\\/MM\\/yyyy"),
                    c.IsYoungDriver
                })
                .ToArray();

           
            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return json;
        }
        // Export Cars from Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(C => C.Make == "Toyota")
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            string json = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
            return json;
        }

        // problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return json;
        }

        // problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(c => new
                {
                    c.Make,
                    c.Model,
                    c.TravelledDistance,
                    parts = c.PartCars.Select(pc => new
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price.ToString("f2")
                    }).ToArray()
                })
                .ToArray();


            var car = new
            {
                car = cars
            };
            string json = JsonConvert.SerializeObject(car, Formatting.Indented);
            return json;
        }

        
    }
}