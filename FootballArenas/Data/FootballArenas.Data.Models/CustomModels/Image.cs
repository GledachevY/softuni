namespace FootballArenas.Data.Models.CustomModels
{
    using System;

    using FootballArenas.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsMainImage = false;
        }

        public string Extension { get; set; }

        public bool IsMainImage { get; set; }

        public int SportComplexId { get; set; }

        public virtual SportComplex SportComplex { get; set; }

        public string Path => $"/images/sportComplexes/{this.Id}.{this.Extension}";

        // The images are stored in file system.
    }
}
