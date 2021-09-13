namespace FootballArenas.Services.Data.User
{
    using System.Collections.Generic;
    using FootballArenas.Data.Models.CustomModels;

    public interface IFootballArenaUserService
    {
        ICollection<FootballArenasUser> GetUsersWithoutSportComplex();
    }
}
