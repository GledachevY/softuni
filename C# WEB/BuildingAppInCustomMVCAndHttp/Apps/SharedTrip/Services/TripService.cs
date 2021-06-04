using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly ApplicationDbContext db;

        public TripService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddTrip(string startPoint, string endPoint, DateTime departureTime, string carImageUrl, int seats,
            string description)
        {
            Trip trip = new Trip()
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                DepartureTime = departureTime,
                Seats = seats,
                Description = description,
                ImagePath = carImageUrl
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public IEnumerable<AllTripsViewModel> ShowAllTrips()
        {
            var trips = this.db.Trips.Select(t => new AllTripsViewModel
            {
                StartPoint = t.StartPoint,
                EndPoint = t.EndPoint,
                DepartureTime = t.DepartureTime.ToString("s"),
                Seats = t.Seats,
                Id = t.Id
            }).ToList();
            return trips;
        }

        public DetailsTripViewModel ShowDetailsForTrip(string id)
        {
            var trip = this.db.Trips.Where(t => t.Id == id).Select(t => new DetailsTripViewModel
            {
                StartPoint = t.StartPoint,
                EndPoint = t.EndPoint,
                DepartureTime = t.DepartureTime.ToString("s"),
                Seats = t.Seats,
                Description = t.Description,
                ImageUrl = t.ImagePath,
                Id = t.Id
            }).FirstOrDefault();

            return trip;
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            var trip = this.db.Trips.FirstOrDefault(t => t.Id == tripId);
            var user = this.db.Users.FirstOrDefault(u => u.Id == userId);
            this.db.UserTrips.Add(new UserTrip()
            {
                User = user,
                Trip = trip
            });
            db.SaveChanges();
        }
    }
}
