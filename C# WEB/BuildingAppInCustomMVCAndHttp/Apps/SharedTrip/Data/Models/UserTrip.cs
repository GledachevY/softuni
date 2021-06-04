using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Data.Models
{
    public class UserTrip
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public String TripId { get; set; }
        public Trip Trip { get; set; }

    }
}
