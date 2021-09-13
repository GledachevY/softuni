namespace FootballArenas.Services.Data.Properties.Image
{
    using System.Threading.Tasks;

    using System.Collections.Generic;

    using FootballArenas.Web.ViewModels.ImageViewModels;
    using FootballArenas.Data.Models.CustomModels;

    public interface IImageService
    {
        public Task SetMainImage(int sportComplexId, List<ImageViewModel> images);

        public Task DeleteImages(int sportComplexId, List<ImageViewModel> images);
    }
}
