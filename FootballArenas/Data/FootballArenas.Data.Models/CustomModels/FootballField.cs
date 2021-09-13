namespace FootballArenas.Data.Models.CustomModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FootballArenas.Data.Common.Models;

    public class FootballField : BaseDeletableModel<int>
    {
        public FootballField()
        {
            this.Reservations = new HashSet<Reservation>();
        }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Size { get; set; }

        [Range(1, 22)]
        public byte RecommendedNumberOfPeople { get; set; }

        public int SportComplexId { get; set; }

        public virtual SportComplex SportComplex { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
