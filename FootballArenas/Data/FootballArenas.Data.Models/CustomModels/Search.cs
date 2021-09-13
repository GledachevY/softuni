namespace FootballArenas.Data.Models.CustomModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections;
    using System.Collections.Generic;

    using FootballArenas.Data.Common.Models;

    public class Search : BaseModel<int>
    {
        public Search()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        [MaxLength(100)]
        public string Text { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public DateTime Time { get; set; }
    }
}
