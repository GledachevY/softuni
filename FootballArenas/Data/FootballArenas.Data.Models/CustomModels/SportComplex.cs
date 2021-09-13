namespace FootballArenas.Data.Models.CustomModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using FootballArenas.Data.Common.Models;

    public class SportComplex : BaseDeletableModel<int>
    {
        public SportComplex()
        {
            this.FootballFields = new HashSet<FootballField>();
            this.Images = new HashSet<Image>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual Address Address { get; set; }

        [ForeignKey("FootballArenasUser")]
        public string FootballArenasUserId { get; set; }

        public virtual FootballArenasUser FootballArenasUser { get; set; }

        public virtual ICollection<FootballField> FootballFields { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
