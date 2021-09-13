namespace FootballArenas.Data.Models.CustomModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using FootballArenas.Data.Common.Models;

    public class Reservation : BaseModel<int>
    {
        [Required]
        public DateTime DateAndTimeOfReservation { get; set; }

        public string FootballArenasUserId { get; set; }

        public virtual FootballArenasUser FootballArenasUserType { get; set; }

        public int FootballFieldId { get; set; }

        public virtual FootballField FootballField { get; set; }
    }
}
