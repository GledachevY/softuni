using System.Collections.Generic;
using System.Linq;
using FootballArenas.Data.Common.Repositories;
using FootballArenas.Data.Models.CustomModels;

namespace FootballArenas.Services.Data.User
{
    public class FootballArenaUserService : IFootballArenaUserService
    {
        private readonly IDeletableEntityRepository<FootballArenasUser> userRepository;

        public FootballArenaUserService(IDeletableEntityRepository<FootballArenasUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public ICollection<FootballArenasUser> GetUsersWithoutSportComplex()
        {
            var result = this.userRepository.AllAsNoTracking().Where(u => u.SportComplex == null).ToList();

            return result;
        }
    }
}
