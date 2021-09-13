using System.Linq;
using FootballArenas.Web.ViewModels.ImageViewModels;

namespace FootballArenas.Services.Data.Properties.Image
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FootballArenas.Data.Common.Repositories;
    using FootballArenas.Data.Models.CustomModels;

    public class ImageService : IImageService
    {
        private readonly IDeletableEntityRepository<SportComplex> sportComplexRepository;
        private readonly IRepository<Image> imageRepository;

        public ImageService(
            IDeletableEntityRepository<SportComplex> sportComplexRepository,
            IRepository<Image> imageRepository)
        {
            this.sportComplexRepository = sportComplexRepository;
            this.imageRepository = imageRepository;
        }

        public async Task SetMainImage(int sportComplexId, List<ImageViewModel> imagesFromController)
        {
            var images = this.imageRepository.All()
                .Where(i => i.SportComplexId == sportComplexId).ToList();

            foreach (var image in imagesFromController)
            {
                var imageToUpdate = images.First(i => i.Id == image.Id);
                imageToUpdate.IsMainImage = image.IsMainImage;
                await this.imageRepository.SaveChangesAsync();
            }
        }

        public async Task DeleteImages(int sportComplexId, List<ImageViewModel> images)
        {
            foreach (var image in images.Where(i => i.IsDelete == true))
            {
                var imageToDelete = this.imageRepository.All().First(i => i.Id == image.Id );
                this.imageRepository.Delete(imageToDelete);
                await this.imageRepository.SaveChangesAsync();
            }
        }
    }
}
