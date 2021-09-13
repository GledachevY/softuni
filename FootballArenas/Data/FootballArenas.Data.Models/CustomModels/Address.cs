using FootballArenas.Data.Models.CustomModels;

namespace FootballArenas.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using FootballArenas.Data.Common.Models;

    public class Address : BaseModel<int>
    {
        [Required]
        [MaxLength(20)]
        public string City { get; set; }

        [Required]
        [MaxLength(20)]
        public string Street { get; set; }

        [Required]
        [MaxLength(20)]
        public string NumberOfStreet { get; set; }

        public int SportComplexId { get; set; }

        public virtual SportComplex SportComplex { get; set; }
    }
}
