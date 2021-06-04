using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.ViewModels.Trips
{
    public class AllTripsViewModel
    {
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public string DepartureTime { get; set; }
        public int Seats { get; set; }
        public string Id { get; set; }
    }
}
