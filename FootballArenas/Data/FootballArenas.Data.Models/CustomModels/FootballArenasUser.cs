namespace FootballArenas.Data.Models.CustomModels
{
    public class FootballArenasUser : ApplicationUser
    {
        public byte Years { get; set; }

        public virtual SportComplex SportComplex { get; set; }
    }
}
