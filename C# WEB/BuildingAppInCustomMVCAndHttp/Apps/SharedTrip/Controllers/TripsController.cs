using System;
using System.Collections.Generic;
using System.Text;
using SharedTrip.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService service;

        public TripsController(ITripService service)
        {
            this.service = service;
        }

        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(string startPoint, string endPoint, DateTime departureTime, string imagePath,
            int seats,
            string description)
        {
            this.service.AddTrip(startPoint, endPoint, departureTime, imagePath, seats,description);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse All()
        {
            var allTrips = this.service.ShowAllTrips();
            return this.View(allTrips);
        }

        public HttpResponse Details(string tripID)
        {
            var trip = this.service.ShowDetailsForTrip(tripID);
            return this.View(trip);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("You must log in");
            }
            var userId = this.GetUserId();
            this.service.AddUserToTrip(tripId,userId);

            return this.Redirect("/Trips/All");
        }
    }
}
