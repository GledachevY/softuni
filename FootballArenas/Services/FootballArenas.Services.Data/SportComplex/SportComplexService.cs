using FootballArenas.Web.ViewModels.ImageViewModels;

namespace FootballArenas.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.IO;

    using FootballArenas.Data.Models;
    using FootballArenas.Data.Common.Repositories;
    using FootballArenas.Data.Models.CustomModels;

    using FootballArenas.Web.ViewModels.SportComplexViewModels;

    public class SportComplexService : ISportComplexService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<SportComplex> sportComplexRepository;
        private readonly IDeletableEntityRepository<FootballArenasUser> userRepository;
        private readonly IRepository<Address> addressRepository;
        private readonly IDeletableEntityRepository<FootballField> footballFieldsRepository;

        public SportComplexService(
            IDeletableEntityRepository<SportComplex> sportComplexRepository,
            IDeletableEntityRepository<FootballArenasUser> userRepository,
            IRepository<Address> addressRepository,
            IDeletableEntityRepository<FootballField> footballFieldsRepository)
        {
            this.sportComplexRepository = sportComplexRepository;
            this.userRepository = userRepository;
            this.addressRepository = addressRepository;
            this.footballFieldsRepository = footballFieldsRepository;
        }

        public async Task AddSportComplex(SportComplexInputViewModel input, string imagePath)
        {
            var address = new Address
            {
                City = input.AddressCity,
                Street = input.AddressStreet,
                NumberOfStreet = input.AddressNumberOfStreet,
            };

            var user = this.userRepository.All().FirstOrDefault(u => u.UserName == input.Username);
            if (user == null)
            {
                throw new ArgumentException("This user is invalid");
            }

            var sportComplex = new SportComplex
            {
                Name = input.Name,
                Address = address,
                FootballArenasUserId = user.Id,
            };

            this.AddFootballFieldsInternal(input, sportComplex);

            await this.AddImages(input, sportComplex, imagePath);

            await this.sportComplexRepository.AddAsync(sportComplex);
            await this.sportComplexRepository.SaveChangesAsync();
        }

        public async Task AddFootballFields(SportComplexInputViewModel input)
        {
            var sportComplex = this.sportComplexRepository.All()
                .First(s => s.Id == input.Id);

            this.AddFootballFieldsInternal(input, sportComplex);
            await this.sportComplexRepository.SaveChangesAsync();
        }

        public async Task EditFootballFields(SportComplexInputViewModel input)
        {
            var fields = this.footballFieldsRepository.All().Where(f => f.SportComplexId == input.Id).ToList();

            foreach (var footballField in fields)
            {
                var inputEditedField = input.FootballFields.First(f => f.Id == footballField.Id);
                footballField.Name = inputEditedField.Name;
                footballField.Size = inputEditedField.Size;
                footballField.RecommendedNumberOfPeople = inputEditedField.RecommendedNumberOfPeople;

                await this.footballFieldsRepository.SaveChangesAsync();
            }
        }

        public async Task DeleteFootballFields(int id)
        {
            var footballFieldToDelete = this.footballFieldsRepository.All().First(f => f.Id == id);
            this.footballFieldsRepository.HardDelete(footballFieldToDelete);
            await this.footballFieldsRepository.SaveChangesAsync();
        }

        private void AddFootballFieldsInternal(SportComplexInputViewModel input, SportComplex sportComplex)
        {
            if (input.FootballFields != null)
            {
                foreach (var fieldInput in input.FootballFields)
                {
                    if (fieldInput.Name == string.Empty || fieldInput.Size == null)
                    {
                        throw new ArgumentException("Empty football field");
                    }

                    var field = new FootballField()
                    {
                        Name = fieldInput.Name,
                        Size = fieldInput.Size,
                        RecommendedNumberOfPeople = fieldInput.RecommendedNumberOfPeople,
                    };

                    sportComplex.FootballFields.Add(field);
                }
            }
        }

        private async Task AddImages(SportComplexInputViewModel viewModel, SportComplex sportComplex, string imagePath)
        {
            if (viewModel.Images != null)
            {
                foreach (var image in viewModel.Images)
                {
                    var extension = Path.GetExtension(image.FileName).TrimStart('.');
                    if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                    {
                        throw new Exception("Invalid image!");
                    }

                    var dbImage = new Image
                    {
                        Extension = extension,
                    };

                    sportComplex.Images.Add(dbImage);
                    var physicalPath = $"{imagePath}/sportComplexes/{dbImage.Id}.{extension}";

                    await using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                    await image.CopyToAsync(fileStream);
                }
            }
        }

        public IEnumerable<HomePageSportComplexViewModel> GetAll()
        {
            return this.sportComplexRepository.AllAsNoTracking().Select(s => new HomePageSportComplexViewModel
            {
                Id = s.Id,
                Description = s.Description,

                // TODO: Get the main image
                ImagePath = $"/images/sportComplexes/{s.Images.First(i => i.IsMainImage == true).Id}.{s.Images.First(i => i.IsMainImage == true).Extension}",
                Name = s.Name,
            }).ToList();
        }

        public HomePageSportComplexViewModel GetById(int id)
        {
            var sportComplex = this.sportComplexRepository.All().Where(s => s.Id == id)
                .Select(s => new HomePageSportComplexViewModel
                {
                    Id = s.Id,
                    ImageList = s.Images.Select(i => new ImageViewModel
                    {
                        Id = i.Id,
                        Extension = i.Extension,
                        IsMainImage = i.IsMainImage,
                    }).ToList(),
                }).First();

            return sportComplex;
        }

        public SportComplex GetOriginalSportComplexById(int id)
        {
            return this.sportComplexRepository.All().First(s => s.Id == id);
        }

        public async Task UploadNewImages(SportComplexInputViewModel input, string imagePath)
        {
            var sportComplex = this.sportComplexRepository.All().First(s => s.Id == input.Id);
            await this.AddImages(input, sportComplex, imagePath);

            await this.sportComplexRepository.SaveChangesAsync();
        }

        public SportComplexInputViewModel GetInputModelById(int id)
        {
            return this.sportComplexRepository.All().Where(s => s.Id == id)
                .Select(s => new SportComplexInputViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    AddressCity = s.Address.City,
                    AddressNumberOfStreet = s.Address.NumberOfStreet,
                    AddressStreet = s.Address.Street,
                    FootballFields = s.FootballFields.ToList(),
                }).First();
        }

        public async Task EditSportComplex(SportComplexInputViewModel input)
        {
            var sportComplexToEdit = this.sportComplexRepository.All().First(s => s.Id == input.Id);

            var addressToEdit = this.addressRepository.All().First(a => a.SportComplexId == sportComplexToEdit.Id);
            addressToEdit.NumberOfStreet = input.AddressNumberOfStreet;
            addressToEdit.City = input.AddressCity;
            addressToEdit.Street = input.AddressStreet;
            await this.addressRepository.SaveChangesAsync();

            sportComplexToEdit.Name = input.Name;
            sportComplexToEdit.Address = addressToEdit;
            await this.sportComplexRepository.SaveChangesAsync();
        }

        public async Task DeleteSportComplexById(int id)
        {
            var sportComplexToRemove = this.sportComplexRepository.All().First(s => s.Id == id);
            this.sportComplexRepository.Delete(sportComplexToRemove);
            await this.sportComplexRepository.SaveChangesAsync();
        }
    }
}
