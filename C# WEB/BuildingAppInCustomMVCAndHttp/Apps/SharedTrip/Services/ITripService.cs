using System;
using System.Collections.Generic;
using System.Text;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services
{
    public interface ITripService
    {
        public void AddTrip(string startingPoint, string endPoint, DateTime departureTime, string carImageUrl,
            int seats, string description);

        public IEnumerable<AllTripsViewModel> ShowAllTrips();

        public DetailsTripViewModel ShowDetailsForTrip(string id);

        public void AddUserToTrip(string tripId, string userId);
    }
}
