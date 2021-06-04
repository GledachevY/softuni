using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.ViewModels.Trips
{
    public class DetailsTripViewModel : AllTripsViewModel
    {
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
