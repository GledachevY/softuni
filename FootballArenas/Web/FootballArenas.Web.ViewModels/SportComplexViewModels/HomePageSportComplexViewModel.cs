namespace FootballArenas.Web.ViewModels.SportComplexViewModels
{
    using System.Collections.Generic;

    using FootballArenas.Web.ViewModels.ImageViewModels;

    using FootballArenas.Data.Models.CustomModels;

    public class HomePageSportComplexViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public List <ImageViewModel> ImageList{ get; set; }
    }
}
