namespace FootballArenas.Data.Models.CustomModels
{
    using System.ComponentModel.DataAnnotations;

    using FootballArenas.Data.Common.Models;

    public class Comment : BaseModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Text { get; set; }

        public int SearchId { get; set; }

        public virtual Search Search { get; set; }
    }
}
