namespace FootballArenas.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using FootballArenas.Web.ViewModels.SportComplexViewModels;
    using FootballArenas.Data.Models.CustomModels;

    public interface ISportComplexService
    {
        public Task AddSportComplex(SportComplexInputViewModel input, string imagePath);

        public IEnumerable<HomePageSportComplexViewModel> GetAll();

        public HomePageSportComplexViewModel GetById(int id);

        public SportComplex GetOriginalSportComplexById(int id);

        public Task UploadNewImages(SportComplexInputViewModel input, string imagePath);

        public SportComplexInputViewModel GetInputModelById(int id);

        public Task EditSportComplex(SportComplexInputViewModel input);

        public Task DeleteSportComplexById(int id);

        public Task AddFootballFields(SportComplexInputViewModel input);

        public Task EditFootballFields(SportComplexInputViewModel input);

        public Task DeleteFootballFields(int id);
    }
}
